namespace _3.CreateModelOfFilesAndFoldersAndSumSize
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Define classes File { string name, int size } and 
    /// Folder { string name, File[] files, Folder[] childFolders } and 
    /// using them build a tree keeping all files and folders on the hard 
    /// drive starting from C:\WINDOWS. Implement a method that calculates 
    /// the sum of the file sizes in given subtree of the tree and test it 
    /// accordingly. Use recursive DFS traversal.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // IMPORTANT, Run visual studio as administrator, otherwise you will get access exception !
            Console.WriteLine("Please wait, this can take a while.");
            Folder root = new Folder("C:/Windows");
            GenerateFolders(root);
            Console.WriteLine("Folder: " + root.Name);
            Console.WriteLine("Size in bytes: " + root.GetFolderSize());
        }

        private static void GenerateFolders(Folder folder)
        {
            try
            {
                var dirs = Directory.GetDirectories(folder.Name);

                string patternForFiles = "*.*";
                var fileNames = Directory.GetFiles(folder.Name, patternForFiles);
                var files = GenerateFiles(fileNames);
                folder.Files.AddRange(files);

                foreach (var dir in dirs)
                {
                    var currentFolder = new Folder(dir);
                    folder.ChildFolders.Add(currentFolder);
                    GenerateFolders(currentFolder);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Exception occured:");
                Console.WriteLine(ex.Message);
            }
        }

        private static List<File> GenerateFiles(string[] filesNames)
        {
            List<File> files = new List<File>();

            for (int i = 0; i < filesNames.Length; i++)
            {
                var newFileInfo = new FileInfo(filesNames[i]);
                long fileSize = newFileInfo.Length;
                files.Add(new File(filesNames[i], fileSize));
            }

            return files;
        }
    }
}
