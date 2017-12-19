/* SCANREAD -- read the sheets, interpret, and output.        */

#include   <stdio.h>
#define EXTERN extern
#include "scanvars.h"

#define    ESCCHAR    '\033'    /* Abort character             */
#define    BUFSIZE    3250      /* Input Buffer Size           */
#define    COMCHAR    '#'       /* Compress Character          */
#define    ENDRECRD   '\015'    /* End of Record Character     */
#define    NRCHAR     'B'       /* Negative Response Character */
#define    PRCHAR     'G'       /* Positive Response Character */
extern char inp_char();

int           bufptr;           /* input stream pointer            */
char          inbuffer[BUFSIZE];/* input buffer                    */
int           freq[10];
int           bubvalue;

scanread()

{

   int        rc,        /* Return code                            */
              sheet,     /* Number of the sheet being read         */
              retry,     /* Count of retrys for checksum mismatch  */
              done,      /* Flag to indicate completion            */
              i;         /* index variable                         */

   done = FALSE;

   /* Flush the serial port */
   inp_flush();

   /* check filename for duplicate and legal usage */
   openfile();
   if (!fpw) {
      delay();
      return;
   }
   /*for (i=0; i<8; i++)  freq[i] = 0;*/

   /* Wait for buffer input or escape character */
   printf("\033[2J\nPress the ESC key to stop scanning forms.\n");
   printf("\nWaiting for input from scanner...");

   /* Main Loop.  Read and process all cards.  */
   for (sheet = 1; ; ) {

      /* Wait for a signal from scanner  */
      while (inp_cnt()==0  &&  (!done)) {
         done = (getcon()==ESCCHAR);
         if (sent_xoff()) outp_char(XON);
      }
      if (done) break;

      /* Throughout this loop, the cursor is left on a line that can be */
      /* wiped out.  In normal operation, this line is repeatedly       */
      /* overwritten with (Receiving | Processing | Finished) sheet ##. */
      printf("\033[99DReceiving sheet %d\033[K", sheet);

      /* Loop until the data is transmitted correctly. */
      for (retry=1; retry<=5; retry++) {
         /* Read one sheet */
         rc = readsheet();
         if (rc==0  ||  rc==-1) break;  /* Either OK or explicit cancel */
         printf("\nBad checksum encountered -- retransmission requested.\n");
         /* outp_char(NRCHAR); */
      }
      if (rc!=0) break;  /* Either an explicit cancel or bad checksum */

      /* outp_char(PRCHAR); */

      printf("\033[99DProcessing sheet %d\033[K", sheet);
      if (abbrev("CON:",filename,3))
         printf("\n");
      /* Distribute the sheet's marks into the ANSWER, etc. arrays. */
      rc = analsheet();

      /* Output the results */
      if (rc==0) {
         switch (outdriver) {
           case 0:  /* The standard GRADER output format */
               GRADoutput();
               break;
           case 1:  /* The RAW output format */
               RAWoutput();
               break;
         }
         printf("\033[99DFinished sheet %d\033[K", sheet);
         sheet++;
      }
      else {
         printf("\033[99DError in sheet %d\033[K\n", sheet);
      }


   } /* End of the loop over all sheets. */
   /*printf("\nFREQ:  %d %d %d %d %d %d %d %d\n", freq[0], freq[1], freq[2], freq[3],
           freq[4], freq[5], freq[6], freq[7]);*/

   printf("\n\nScanning terminated.\n");
   if (fpw) {
      fclose(fpw);
      printf("\n%d sheets stored in the file '%s'.\n", sheet-1, filename);
      stats_count++;
      stats_total += sheet-1;
      if (sheet-1>stats_max) stats_max = sheet-1;
      if (nextstep()) {
         kermdirs();
         system("MSKERMIT");
         printf("\n\n\033[0mTo actually grade the test, you must log on to another\n");
         printf("terminal and run the GRADER program.\n");
         printf("See the GRADER ROSTER User's Guide for more information.\n\n");
         delay();
      }
   }
}


/* get a character from the keyboard, if available */
getcon()
  {
    int status;
    struct regval {int ax,bx,cx,dx,si,di,ds,es;};
    struct regval call_reg,ret_reg;

    call_reg.ax = 0x0600;
    call_reg.dx = 0x00ff;
    status = sysint21(&call_reg,&ret_reg);
    if (status&0x40) return (EOF);
    return (ret_reg.ax & 0xff);
  }


/* check filename against disk to see if it is legal or if a duplicate exists */
openfile()

{
FILE  *fopen();
char  line[70], word[70];
int j;

   /* check to see if file already exists */
   if ((fpw = fopen(filename,"r"))!=NULL) {
      /* if it does, then make user decide what to do with it */
      printf("\033[2J\n\nThe file you are attempting to store your data in");
      printf(" already exists.\n\n");
      printf("Do you wish to:  O)verwrite the old file,\n");
      printf("                 A)ppend to the end of the old file, or\n");
      printf("                 Q)uit and return to the main menu.\n");
      printf("                 ");
      fgets(line,70,stdin);
      j = 0;
      parseword(line, word, &j);
      upper(word);

      if (abbrev("OVERWRITE", word, 1)) {
         /* erase current file */
         fclose(fpw);
         fpw=fopen(filename,"w");
         fclose(fpw);
         fpw=fopen(filename,"a");
         return;
      }

      if (abbrev("APPEND", word, 1)) {
         fclose(fpw);
         fpw=fopen(filename,"a");
         return;
      }

      if (!abbrev("QUIT", word, 1))
         printf("\nError in input -- only OVERWRITE, APPEND, or QUIT allowed.");
      fclose(fpw);
      fpw = NULL;
      return;
   }

   else
      /* if filename doesn't exist, check it for being a legal name */
      if ((fpw = fopen(filename,"a"))==NULL) {
         printf("\033[2J\n\nInvalid filename -- file not opened.");
       }
}


readsheet()

/* READSHEET -- read a single sheet from the scanner                   */
/* This function returns an integer return code:                       */
/*    0 -- Sheet was completely read and the checksum matched.         */
/*    1 -- Sheet was completely read, but the checksum did NOT match.  */
/*   -1 -- The user pressed the escape character to abort the process. */

{
   int checksum;

   /* Process first character -- we are called only AFTER the first char is read */
   bufptr = 0;
   inbuffer[bufptr] = inp_char();
   checksum = inbuffer[bufptr];

   /* Loop until end of card is reached */
   while (inbuffer[bufptr++]!=ENDRECRD)
   {
      /* Process 1 character */
      while (inp_cnt()==0) {
         if (getcon()==ESCCHAR) return(-1);
         if (sent_xoff()) outp_char(XON);
      }
      inbuffer[bufptr] = inp_char();
      checksum ^= inbuffer[bufptr];
   }

   /* Get check character */
/*    while (inp_cnt()==0) {
         if (getcon()==ESCCHAR) return(-1);
         if (sent_xoff()) outp_char(XON);
      }
   inbuffer[bufptr] = inp_char();
*/
   checksum &= 0x7f;

   /* Make sure check characters agree */
   return (0);
}


int column,
    row;


analsheet()

/* ANALSHEET -- analyze one sheet's marks, filling the ANSWER arrays */

  {
    int           stoppt,
                  i;

    /* Initialize all answer arrays to 0. */
    for (i=0; i<MAXITEMS; i++) {
       answer[i]=0;
       if (i<=14)  { id[i]=0; misc[i]=0; option[i]=0; }
     }

     row = 0;
     column = 0;
     do1mark(-1, -1, -1);    /* Initialize the lower-level routine. */
     stoppt = bufptr-1;
     bufptr = 0;

     /* Loop until all the characters read are processed */
     while (bufptr < stoppt)

       {
         /* Check to see if characters are compressed */
         if (inbuffer[bufptr]==COMCHAR)  {

            for (i=inbuffer[bufptr+1]-'@'; i>0; i--)
                {
                bubvalue = inbuffer[bufptr+2]-'0';
                do1mark(row, column, bubvalue);
                incposition();
                }

             /* Skip over compression characters */
             bufptr += 2;
           }

          else

           {
             /* process this bubble position */
             bubvalue = inbuffer[bufptr]-'0';
             do1mark(row, column, bubvalue);
             incposition();
           }

         bufptr++;

      }

   return (form==-2);  /* This returns 0 if a the form was either recognized */
                       /* or no marks appeared in the body of the form.      */
}


/* Increments the column and if necessary, the row */
incposition()

{
   column++;

   if (column>=48)  {
      row++;
      column = 0;
   }
}

/* NEXTSTEP -- display directions for the next step  */
nextstep()
{
   int done, dokermit, i, j;
   char line[MAXLINE], word[MAXLINE];

   printf("\n\nTo use this file with the mainframe GRADER,\n");
   printf("it must first be uploaded with the KERMIT program.\n");

   done = FALSE;
   while (!done) {
      printf("\nDo you want to upload your data now? (YES/NO): ");
      fgets(line,MAXLINE,stdin);
      upper(line);
      j=0;
      i=parseword(line,word,&j);
      if (abbrev("YES", word, 1)) {
         dokermit = TRUE;
         done = 1;
      }
      else if (abbrev("NO", word, 1)) {
         dokermit = FALSE;
         done = 1;
      }
      else printf("\nReply with 'YES' or 'NO'.");
   }
   return(dokermit);
}


/* KERMDIRS -- display directions for using MSKERMIT */
kermdirs()
{
   static char *dirs[] = {
      "\n\n\033[1mMSKERMIT directions\033[0m\n\n",
      "  1.  Enter 'CONNECT' at the prompt below.\n",
      "  2.  Press the RETURN key and enter 'KSUVM'.\n",
      "  3.  Enter 'VT100' at the 'ENTER TERMINAL TYPE' prompt.\n",
      "      (The VM/370 logo should be displayed at this point.)\n",
      "  4.  Press RETURN and follow the directions at the top of the screen.\n",
      "  5.  At the CMS R; prompt, enter 'KERMIT RECEIVE'.\n",
      "  6.  Press and hold the ALT key then press and release the 'X' key.\n",
      "  7.  Release the ALT key.\n",
      "  8.  Enter 'SEND ",
      "'.\n",
      "  9.  When the file transfer completes, enter 'CONNECT'.\n",
      " 10.  Enter the CMS command 'LOGOFF'.\n",
      " 11.  Repeat steps 6 and 7.\n",
      " 12.  Enter the 'EXIT' command.\n\n"
   };
   int i;

   for (i=0; i<10; i++)
      printf(dirs[i]);
   printf("%s", filename);
   for (i=10; i<15; i++)
      printf(dirs[i]);
}
