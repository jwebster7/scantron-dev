/* RAWOUT -- outputs one sheet's data in a "raw" format    */
/*        -- intended to interface with dBASE, 1-2-3, etc. */

#include <stdio.h>
#define EXTERN extern
#include "scanvars.h"


RAWoutput()
{
   group(id, 9);
   group(option, 5);
   group(answer, items);
}
