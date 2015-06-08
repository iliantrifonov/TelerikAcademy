namespace _02.NameAndDescriptionOfCategories
{
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// Write a program that retrieves the name and description of all categories in the Northwind DB.
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
                var command = new SqlCommand("SELECT [CategoryName] ,[Description] FROM Categories", databaseConnection);
                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Name: {0}, Description: {1}", reader["CategoryName"], reader["Description"]);
                    }
                }
            }
        }
    }
}
