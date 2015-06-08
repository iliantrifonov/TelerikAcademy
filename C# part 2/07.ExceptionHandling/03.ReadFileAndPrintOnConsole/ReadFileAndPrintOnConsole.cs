using System;
using System.IO;
using System.Security;

namespace _03.ReadFileAndPrintOnConsole
{
    //Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…). Be sure to catch all possible exceptions and print user-friendly error messages.

    class ReadFileAndPrintOnConsole
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the full path of the file you want to read: ");
            string filePath = Console.ReadLine();
            try
            {
                string fileContent = File.ReadAllText(filePath);
                Console.WriteLine("The content of the file is: ");
                Console.WriteLine(fileContent);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file path contains a directory that cannot be found.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File '{0}' was not found.", filePath);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("No file path given.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The entered file path is incorrect.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The entered file path is too long - 248 characters is the maximum.");
            }
            catch (UnauthorizedAccessException uoae)
            {
                Console.WriteLine(uoae.Message);
            }
            catch (SecurityException)
            {
                Console.WriteLine("You don't have the required permission to access this file.");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Invalid file path format.");
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            
        }
    }
}
