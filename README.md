# KSU iTAC Scantron Scanner Application

## Purpose
This is a project for rewriting the Kansas State University Help Desk scantron program to be more legible and user-friendly. The original program requires users to navigate through the command prompt. This new version uses Windows Application Forms for a less confusing user experience.

## Current Work
GUI reconfiguration for UX.  

MessageCenter for notifying users about the status of the program.  

Making the Configuration editable via form fields.  

## Potential Work  
Implementing multi-threading so one thread can handle reading in the data from the buffer, and another can run the application. This would allow for complete control of the scanner from the application and account for unforeseen exceptions by allow the main application to run, even if an exception is thrown from the scan thread.  

If work is continued on the .NET framework, one could use the [System.Threading](https://docs.microsoft.com/en-us/dotnet/api/system.threading?view=netframework-4.8) Namespace. 

## Details
The OLDSCANTRON folder contains all of the files from the original program written in 1987. Retrieved from Niel Erdwien.

Error fixing and detailed information on the architecture of the program and its methods are on the wiki page: https://github.com/prometheus1994/scantron-dev/wiki

## Framework  
.NET Framework 4 or greater.  

## Dependencies  
**System.IO.Ports:** This is used for importing the [SerialPort libraries](https://docs.microsoft.com/en-us/dotnet/api/system.io.ports?view=netframework-4.8).  
**System.Collections.Generic:** This is used for using [C#'s Generic Data Structures](https://docs.microsoft.com/en-us/dotnet/standard/collections/).  
**System.Linq:** This is used for using the [LINQ Libraries](https://docs.microsoft.com/en-us/dotnet/api/system.linq?view=netframework-4.8).  
**System.Windows.Forms:** This is used for creating [Windows GUI Applications](https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms?view=netframework-4.8).  
**System.Drawing:** This is used in tandem for creating Windows GUI Applications and for importing **Color** objects.  
**System.Threading:** This is used for possible multi-threading.  
