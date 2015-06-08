namespace _03.GetCategoriesAndNamesOfProducts
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Write a program that retrieves from the Northwind database
    /// all product categories and the names of the products in each category.
    /// Can you do this with a single SQL query (with table join)?
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
                var command = new SqlCommand("SELECT c.CategoryName, p.ProductName FROM Categories c INNER JOIN Products p ON p.CategoryID = c.CategoryID;", databaseConnection);
                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Category Name: {0}, Product name: {1}", reader["CategoryName"], reader["ProductName"]);
                    }
                }
            }
        }
    }
}
