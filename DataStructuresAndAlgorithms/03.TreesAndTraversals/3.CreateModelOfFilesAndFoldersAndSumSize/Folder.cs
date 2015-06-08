namespace _3.CreateModelOfFilesAndFoldersAndSumSize
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> ChildFolders { get; set; }

        public long GetFolderSize()
        {
            long sum = 0;

            foreach (var file in this.Files)
            {
                sum += file.Size;
            }

            foreach (var childFolder in this.ChildFolders)
            {
                sum += childFolder.GetFolderSize();
            }

            return sum;
        }
    }
}
