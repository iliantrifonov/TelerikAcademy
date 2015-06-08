namespace _07.AppendRowsToExcelFile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.OleDb;

    /// <summary>
    /// Implement appending new rows to the Excel file.
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

            for (int i = 1; i < 30; i++)
            {
                InsertDataIntoEcxel("Added" + i, i+20, dbCon);
            }
        }
        
        public static void InsertDataIntoEcxel(string name, double score, OleDbConnection connection)
        {
            OleDbCommand myCommand = new OleDbCommand("INSERT INTO [Sheet1$] (Name,Score) VALUES (@Name,@Score)", connection);
            connection.Open();
            using (connection)
            {
                myCommand.Parameters.AddWithValue("@Name", name);
                myCommand.Parameters.AddWithValue("@Score", score);
                myCommand.ExecuteNonQuery();
            }
        }
    }
}
