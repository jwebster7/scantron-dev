/* EXTERN should be defined either as "extern" or null */

#define TRUE 1
#define FALSE 0
#define MAXLINE 70

#define NONE  0
#define ODD   1
#define EVEN  3
#define XON 0x11

#define FORMS 4
#define MAXITEMS 256

EXTERN int parity;
EXTERN int scanexit;
EXTERN int speed;
EXTERN char filename[MAXLINE];
EXTERN FILE *fpw;

EXTERN int form;         /* This is set to the subscript into the SKUNKTABL  */
                         /* array which represents the form being processed. */
EXTERN int items;
EXTERN char optcol;
EXTERN int outdriver;    /* An integer that selects which output driver to   */
                         /* use:  0 ==> GRADER format,  1 ==> RAW format     */
EXTERN int multmarks;    /* Set to TRUE by ANALSHEET if multiple marks were  */
                         /* found in the sheet.                              */
EXTERN int multout;      /* Set to TRUE under user control if multiple marks */
                         /* are to be allowed in the output.                 */
EXTERN int stats_count, stats_max, stats_total;

/* arrays containing card info */
EXTERN int answer[256],
           id[15],
           option[15],
           misc[15];
