namespace _01.GetNumberOfRowsInCategories
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// Write a program that retrieves from the Northwind sample database 
    /// in MS SQL Server the number of  rows in the Categories table.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "data source=NIKKI-PC;initial catalog=Northwind;integrated security=True;MultipleActiveResultSets=True;";
            SqlConnection databaseConnection = new SqlConnection(connectionString);
            databaseConnection.Open();
            using (databaseConnection)
            {
                var command = new SqlCommand("SELECT COUNT(*) FROM Categories", databaseConnection);
                int categoryCount = (int)command.ExecuteScalar();

                Console.WriteLine("The number of rows in Categories is: {0}", categoryCount);
            }
        }
    }
}
