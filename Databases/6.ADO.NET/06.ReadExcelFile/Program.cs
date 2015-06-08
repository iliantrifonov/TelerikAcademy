namespace _06.ReadExcelFile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.OleDb;
    using System.Data;

    /// <summary>
    /// Create an Excel file with 2 columns: name and score:
    /// Write a program that reads your MS Excel file through the 
    /// OLE DB data provider and displays the name and score row by row.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var connectionString = new OleDbConnectionStringBuilder();
            connectionString.DataSource = "../../table.xlsx";
            connectionString.Provider = "Microsoft.ACE.OLEDB.12.0";
            connectionString.PersistSecurityInfo = true;
            connectionString.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES");

            var dbCon = new OleDbConnection(connectionString.ConnectionString);
            dbCon.Open();
            using (dbCon)
            {
                OleDbCommand comand = new OleDbCommand("select * from [Sheet1$]", dbCon);
                OleDbDataReader reader = comand.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        double score = (double)reader["Score"];
                        Console.WriteLine("{0} - score: {1}", name, score);
                    } 
                }                
            }
        }
    }
}
