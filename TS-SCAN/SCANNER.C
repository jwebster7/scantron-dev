/* SCANNER -- main program for the interface to the NCS scanner */
#include <stdio.h>

/* Set EXTERN to null so as to actually define the variables.   */
#define EXTERN

/* Include the file containing global variable declarations.    */
#include "scanvars.h"

main(argc,argv)
{

     char line[MAXLINE], word[MAXLINE];
     int i, j;

     initvars();    /* initialize variables */
     stats_count = 0;
     stats_total = 0;
     stats_max   = 0;

     init_comm();   /* initialize comm port */
     set_xoff(TRUE);

     /* Main Loop */
     scanexit = FALSE;
     while(!scanexit)
       {

          /* print instructions, menu, and prompt */
          inst();
          menu();
          printf("\nScanner>");

          /* get a command and process it */
          fgets(line,MAXLINE,stdin);
          upper(line);
          j=0;
          i=parseword(line,word,&j);
          if (i==0)  /* NOP */;
          else if (word[0] == '?'  ||  abbrev("HELP", word, 1))
                   helpmenu();
          else if (abbrev("SET", word, 1))
                   setparm(line,j);
          else if (strcmp("A", word)==0)
                   multset();
          else if (strcmp("B", word)==0)
                   itemset();
          else if (strcmp("C", word)==0)
                   fnset();
          else if (strcmp("D", word)==0)
                   colset();
          else if (abbrev("QUIT", word, 1)  ||  abbrev("EXIT", word, 2))
                   scanexit=TRUE;
          else if (abbrev("STATUS", word, 2))
                   scanstatus();
          else if (abbrev("VERSION", word, 1))
                   pversion();
          else if (abbrev("READ", word, 1))
            {
              scanread();
              initvars();    /* reset variables to default values */
            }
          else if (abbrev("MSKERMIT", word, 3) || abbrev("KERMIT", word, 3))
             {
                   kermdirs();
                   system("MSKERMIT");
             }
          else if (strcmp("DOS", word)==0)
             {
                   system(&line[j]);
                   delay();
             }
          else { printf("\nInvalid command '%s'\n",word); delay(); }
       }
     uninit_comm();  /* clean up */
  }


/* simple function to print the present version of this program */
pversion()

  {
    printf("\nScanner Version 1.3, October, 1987\n");
    printf("(c) 1987 Kansas State University Computing Activities\n");
    /* Delay, so version can be read */
    delay();
  }



/* list of instructions for user to follow */
inst()
{
 static char *instruct[] = {
   "\033[2J\033[1m     Instructions for scanner use:\033[0m",
   "\n\n 1.  Make sure the scanner is on",
   "\n 2.  Place your floppy disk in drive B:",
   "\n 3.  Set any options necessary (by selecting letter or typing entire",
   " command)",
   "\n 4.  Enter the READ command to begin scanning forms",
   "\n 5.  Feed sheets into scanner",
   "\n 6.  After all your forms have been scanned, press the ESC key.",
   "\n     (This key is on the upper row of keys in the third column from the left)",
   "\n 7.  Upload your file to the mainframe.  (Additional instructions",
   "\n     will appear for this step.)",
   "\n\n For general file transfer, enter MSKERMIT at the prompt below."
    };
   int i;
     for( i=0; i<12; i++)
          printf(instruct[i]);
   return;
}


/* menu of user options */
menu()
{
 static char *menulist[] = {
   "\n\n Options:\n",
   "\n     A)  SET MULTIPLE  YES or NO    (responses per question allowed)",
   "\n     B)  SET ITEMS  ###   (where ### is the number of items per card)",
   "\n     C)  SET FILENAME  filename   (where filename is a legal filename)",
/* "\n     D)  SET OPTCOL  #   (to be used for Card number)", */
   "\n\n     R)  READ   (data from scanner)\n"
    };
   int i;
     for( i=0; i<5; i++)
          printf(menulist[i]);
     printf("\n\033[1m MULTIPLE = ");
     if (multout == FALSE)
          printf("NO,");
       else
          printf("YES,");
     printf(" ITEMS = %d,",items);
     printf(" FILENAME = %s",filename);
 /*  printf(" OPTCOL = %d",optcol); */
     printf("\n\033[0m");
   return;
}


/* Activated by help command.  Gives all possible commands */
helpmenu()
{
   static char *menulist[] = {
          "\n Read input from scanner",
          "\n Quit program and return to DOS",
          "\n Help by giving this message",
          "\n SET a parameter",
          "\n     PARITY (EVEN,ODD,NONE)",
          "\n     BAUD (110-9600)",
          "\n     MULTIPLE (ON,OFF)",
          "\n     FILENAME (filename)",
          "\n     ITEMS (1-300)",
          "\n     OPTCOL (1-5)",
          "\n STatus of SCANNER",
          "\n Version -- Print version number"
   };
   int i;
   for (i=0; i<12; i++)
      printf(menulist[i]);
   delay();
   return;
}


/* set output to single/multiple answers/question */
multset()
{
   int done;
   char line[MAXLINE], word[MAXLINE];
   int i,j;

   printf("\033[2J");
   done = FALSE;
   while (!done) {
      printf("\nAre multiple answers per question allowed? (YES/NO): ");
      fgets(line,MAXLINE,stdin);
      upper(line);
      j=0;
      i=parseword(line,word,&j);
      if (strcmp(word,"YES")==0  ||  strcmp(word,"ON")==0)  {
         multout = TRUE;
         done = 1;
      }
      else if (strcmp(word,"NO")==0  ||  strcmp(word,"OFF")==0)  {
         multout = FALSE;
         done = 1;
      }
      else printf("\nInvalid MULTIPLE value.");
   }
}


/* change number of last item to output */
itemset()
{
        char line[MAXLINE];
        int i,j;
        printf("\033[2J");
        j=0;
        while (j<1 || j>255)
         {
           printf("\n Enter the number of items per form   (1-255) ");
           fgets(line,MAXLINE,stdin);
           i = sscanf(line,"%d",&j);
           if (j<1 || j>255) printf("\n\n Incorrect no. of items specified.\n");
         }
        items = j;
}


/* change output column used for card number */
colset()
{
        char line[MAXLINE];
        int i,j;
        printf("\033[2J");
        j=0;
        while (j<1 || j>5)
         {
           printf("\n Enter the option column used for the form # (1-5) ");
           fgets(line,MAXLINE,stdin);
           i = sscanf(line,"%d",&j);
           if (j<1 || j>5) printf("\n\n Incorrect column specified.\n");
         }
        optcol = j;
}


/* change filename */
fnset()
{
        char line[MAXLINE], word[MAXLINE];
        int i,j;

        printf("\033[2J");
        printf(" Enter filename   (in the form:  drive:filename.ext) ");
        fgets(line,MAXLINE,stdin);
        j=0;
        parseword(line,word,&j);
        i = sscanf(word,"%s",filename);
        upper(filename);
}


parseword(s,w,i)
char s[], w[] ;
int *i ;
{
/* parseword parses a word from the input array. It returns the length of */
/* the word parsed from the input array, and the third parm gets the start*/
/* place for the next scan from the input line.  For the initial scan a   */
/* value of 0 should be passed in.                                        */

        int j;
        j = 0;

        while( s[*i]!='\0' && s[*i]!='\n' && s[*i]==' ' )
                ++*i ;
        while( s[*i]!='\0' && s[*i]!='\n' && s[*i]!=' ' )
                w[j++] = s[(*i)++] ;
        w[j] = '\0' ;
        return( j ) ;
}



/* This routine prints the status of various parameters */
/* that can be changed by the user. */
scanstatus()
{
        unsigned int i;

        /* let user know current settings of things */
        printf("\nBaud rate %d\n", speed);

        if (parity == ODD)
                printf("Parity odd\n");
        else if (parity == EVEN)
                printf("Parity even\n");
        else
                printf("Parity none\n");

        if (multout)
                printf("Multiple yes\n") ;
        else
                printf("Multiple no\n") ;

        printf("Items per form is %d\n",items);
        printf("Option Column used to specify card no. is %d\n",optcol);
        printf("Output filename is %s\n",filename);
        if (outdriver==0)
           printf("Outdriver grader\n");
        else printf("Outdriver raw\n");
        printf("Total files read: %d\n", stats_count);
        printf("Total sheets read: %d\n", stats_total);
        printf("Maximum sheets read: %d\n", stats_max);
        delay();

}


/* This routine allows you to change any of the setable parameters */
setparm( s, i )
char s[];
int  i;
{
        /* first word is "SET", so now find out what to set */
        int j ; char w[MAXLINE] ;

        j = parseword(s,w,&i) ;
        if (j==0) {
                printf("\nMissing keyword after the SET command."); delay (); }
        else if (abbrev("BAUD",w,3)) {
                parseword( s, w, &i);
                i = sscanf(w,"%d",&j);
                if (setbaud(j,parity)) speed = j;
                   else delay();
        }
        else if (abbrev("PARITY",w,3)) {
                parseword(s, w, &i);
                if (abbrev("EVEN", w, 1))      parity = EVEN;
                else if (abbrev("ODD", w, 1))  parity = ODD;
                else if (abbrev("NONE", w, 1)) parity = NONE;
                else { printf("\nInvalid parity value."); delay(); }
                setbaud(speed, parity);
        }
        else if (abbrev("MULTIPLE", w, 1)) {
                parseword(s, w, &i);
                if (strcmp(w,"YES")==0  ||  strcmp(w,"ON")==0)
                   multout = TRUE;
                else if (strcmp(w,"NO")==0  ||  strcmp(w,"OFF")==0)
                   multout = FALSE;
                else { printf("\nInvalid MULTIPLE value."); delay(); }
        }
        else if (abbrev("FILENAME", w, 1)) {
                parseword(s, w, &i);
                i = sscanf(w,"%s",filename);
        }
        else if (abbrev("ITEMS", w, 1)) {
                parseword(s, w, &i);
                i = sscanf(w,"%d",&j);
                if ((j > 0) && (j <= 300)) items = j;
                else { printf("\nInvalid items value."); delay(); }
        }
        else if (abbrev("OPTCOL", w, 3)) {
                parseword(s, w, &i);
                i = sscanf(w,"%d",&j);
                if ((j > 0) && (j < 6)) optcol = j;
                else { printf("\nInvalid OPTCOL value."); delay(); }
        }
        else if (abbrev("OUTDRIVER", w, 3)) {
                parseword(s, w, &i);
                if ((j = setoutd(w)) >= 0) outdriver = j;
                   else delay();
        }
        else
                { printf("\nInvalid keyword '%s' after the SET command.", w);
                  delay(); }
}


/* setbaud sets the baud rate, and parity for the z100 micro-computer. */
/* valid is returned so that caller knows if the baud rate was set.    */
setbaud(rate,par)
int rate,par;
{
        struct {int ax,bx,cx,dx,si,di,ds,es;} srv, rrv;
        int valid, bits;

        valid = TRUE;
        switch (rate) {
                case 110:
                        rate = 0;
                        break;
                case 300:
                        rate = 2;
                        break;
                case 600:
                        rate = 3;
                        break;
                case 1200:
                        rate = 4;
                        break;
                case 2400:
                        rate = 5;
                        break;
                case 4800:
                        rate = 6;
                        break;
                case 9600:
                        rate = 7;
                        break;
                default:
                        valid = FALSE;
                        printf("\nInvalid baud rate");
                        delay();
                        break;
        }
        if (valid) {    /* we have a valid baud rate, so set it to that */
                /* check what parity we have so bits is set correctly */
                if ( par == NONE ) bits = 3;
                else bits = 2;
                srv.dx = 0;
                srv.ax = ( rate<<5 ) + ( par<<3 ) + bits;
                uninit_comm();
                sysint ( 0x14, &srv, &rrv );
                /* system interrupt 14H to get routine to set port speed */
                init_comm();
        }
        return( valid );
}


setoutd(name)
char name[];
{
   if (abbrev("GRADER", name, 4))
      return(0);
   else if (strcmp("RAW", name)==0)
      return(1);
   else {
      printf("\nInvalid OUTDRIVER value.");
      return(-1);
   }
}


/* This period waits for the RETURN key to be pushed before proceeding */
delay()
  {
  char line[MAXLINE];

     printf("\n\nPress \033[5mRETURN\033[0m to continue...");
     fgets(line,MAXLINE,stdin);

  }


/* Initialize all program variables */
initvars()
{
        parity   = EVEN;
        speed    = 9600;
        multout  = FALSE;
        items    = 50;
        optcol   = 5;
        outdriver= 0;

        setbaud(speed, parity) ;
        strcpy(filename,"B:SCANNER.DAT");

}
