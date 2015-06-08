using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UploadZipToDb
{
    public class UploadedTextFile
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public string ZipName { get; set; }

        public byte[] Data { get; set; }
    }
}