/* This file is used to output the interpreted data */
/* in a format compatible with grader roster */

#include <stdio.h>
#define EXTERN extern
#include "scanvars.h"

/* GRADoutput -- output one sheet's answers (possibly multiple output cards) */
GRADoutput()
{
   int cardnomark, firstans;

   cardnomark = 2;
   for (firstans=0; items-firstans>0; firstans += 50) {
      /* set card number */
      if (items>50) option[optcol] = cardnomark;
      GRADout1(&answer[firstans],id,option,misc,
                   (  (items-firstans > 50)  ?  50 : items-firstans  ));
                   /* The above expression is "min(items-firstans, 50)"  */
      cardnomark = 2*cardnomark;
   }
}


GRADout1(answer,id,option,misc,items)

/* data arrays */
int    answer[],
       id[],
       option[],
       misc[];

/* number of last item to be output */
int  items;

{
   int i;

   /* Write data to file in GRADER format */
   group(id,9);
   fprintf(fpw,", ");
   group(option,5);
   fprintf(fpw,",");
   if ((multout == FALSE) || (multmarks==FALSE)) {
        /* Single answer output */
        fprintf(fpw,"   '");
        group(answer,items);
        fprintf(fpw,"'\n");
    }
    else {
        /* Multiple answer output */
        fprintf(fpw,"5, '");
        Mgroup(5,answer,items);
        fprintf(fpw,"'\n");
        for (i=4; i>0; i--) {
             fprintf(fpw,"         ,      ,%d, '",i);
             Mgroup(i,answer,items);
             fprintf(fpw,"'\n");
        }
     }
}


/* This function outputs the data from one array */
group(array,number)

int  array[],       /* Array containing data */
     number;        /* Number of elements in the array */

{

   int i, j;
   char outchar;

   for (i = 1; i<=number; i++) {
      outchar = '-';
      for (j=0; j<10; j++) {
         if (array[i]  &  (1<<j) )
            if (outchar == '-')
                 outchar = '0' + j;  /* This works in ASCII only */
            else outchar = '*';
      }
      fprintf(fpw, "%c", outchar);
   }
}


/* This functions outputs multiple answers/question */
Mgroup(bitnum,array,number)

int  bitnum,     /* Number of the bit to test                  */
     array[],    /* Data array                                 */
     number;     /* Number of elements in the array to process */

{
   int  bitmask,    /* Mask to test the bit being output       */
        i;
   char outchar;

   bitmask = 1<<bitnum;

   for (i = 1; i<=number; i++) {
      /* Output the current number if it was marked */
      outchar = ' ';
      if (array[i]  &  bitmask)
         outchar = '0' + bitnum;  /* This works in ASCII only */
      fprintf(fpw, "%c", outchar);
    }
}
