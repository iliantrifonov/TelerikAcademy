namespace _05.StoreImagesToHardDisk
{
    using System.Data.SqlClient;
    using System.IO;

    /// <summary>
    /// Write a program that retrieves the images for all categories in the 
    /// Northwind database and stores them as JPG files in the file system.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "data source=HOME-PC;initial catalog=Northwind;integrated security=True;MultipleActiveResultSets=True;";
            SqlConnection databaseConnection = new SqlConnection(connectionString);
            databaseConnection.Open();
            using (databaseConnection)
            {
                SqlCommand command = new SqlCommand("SELECT CategoryName, Picture FROM [Categories]", databaseConnection);
                var reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string fileName = "../../" + reader["CategoryName"].ToString().Replace("/", string.Empty) + ".bmp";
                        var pic = (byte[])reader["Picture"];
                        WriteToBinaryFile(fileName, pic);
                    }
                }
            }
        }

        private static void WriteToBinaryFile(string fileName, byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            int offset = 78;
            using (stream)
            {
                stream.Write(fileContents, offset, fileContents.Length - offset);
            }
        }
    }
}
