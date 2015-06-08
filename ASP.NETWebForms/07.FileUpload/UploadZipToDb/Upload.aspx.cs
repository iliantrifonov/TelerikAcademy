using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ionic.Zip;

namespace UploadZipToDb
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Upload_UploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            var upload = sender as AsyncFileUpload;
            if (!upload.HasFile)
            {
                return;
            }

            if (!upload.FileName.EndsWith(".zip"))
            {
                Response.Write("Invalid file, you need to upload a zip");
                return;
            }

            var zipped = upload.FileBytes;

            var context = new UploadDbContext();

            using (var stream = new MemoryStream(zipped))
            {
                using (var zipStream = new ZipInputStream(stream))
                {

                    ZipEntry entry = zipStream.GetNextEntry();
                    while (entry != null)
                    {
                        using (var extractedFileStream = new MemoryStream())
                        {
                            zipStream.CopyTo(extractedFileStream);
                            
                            var result = new byte[extractedFileStream.Length];
                            extractedFileStream.Read(result, 0, result.Length);

                            var fileToUpload = new UploadedTextFile()
                            {
                                Data = result,
                                FileName = entry.FileName,
                                ZipName = upload.FileName
                            };

                            context.Files.Add(fileToUpload);
                            context.SaveChanges();
                        }

                        entry = zipStream.GetNextEntry();
                    }
                }
            }

            Response.Write("File uploaded to database.");
        }

        protected void Upload_UploadedFileError(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {

        }
    }
}