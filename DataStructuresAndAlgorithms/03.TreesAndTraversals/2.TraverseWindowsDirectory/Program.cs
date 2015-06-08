namespace _2.TraverseWindowsDirectory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    /// <summary>
    /// Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display all files matching the mask *.exe. Use the class System.IO.Directory.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // IMPORTANT, run the visual studio as Administrator, from an administrator account, 
            // otherwise this will give an exception as you will not have the security rights to 
            // traverse these directories !
            string filePattern = "*.exe";
            string path = "C:/Windows";
            var filesMatchingPattern = Directory.EnumerateFiles(path, filePattern, SearchOption.AllDirectories);

            foreach (var fileName in filesMatchingPattern)
            {
                Console.WriteLine(fileName);
            }
        }
    }
}
