/*	standard i/o header file for c86
*/

#ifdef _C86_BIG
#define NULL (0L)
#else
#define NULL 0
#endif

#define EOF (-1)	/* standard end of file */
#define EOS '\0'	/* standard end of string */
#define AREAD 0		/* ascii read */
#define AWRITE 1	/* ascii write */
#define AUPDATE 2	/* ascii update (take care with this one) */
#define BREAD 4		/* binary update */
#define BWRITE 5	/* binary write */
#define BUPDATE 6	/* binary update */
typedef char FILE;
#define getchar() fgetc(stdin)
#define getc(x) fgetc(x)
#define putchar(x) fputc(x,stdout)
#define putc(x,y) fputc(x,y)
#define ungetch(c) ungetc(c,stdin)

/*	definition for setjmp and longjmp
*/

#ifdef _C86_BIG
typedef int jmp_buf[4];
#else
typedef int jmp_buf[3];
#endif

extern FILE *stdin, *stdout, *stderr;

/*	end of standard header file
*/
