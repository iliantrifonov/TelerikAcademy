namespace _04.AddNewProduct
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
                AddProduct("Some name", 1, 1, databaseConnection);
                Console.WriteLine("Product added!");
            }
        }

        public static void AddProduct(string name, int supplierId, int categoryId, SqlConnection databaseConnection)
        {
            var command = new SqlCommand("INSERT INTO Products(ProductName, SupplierID, CategoryID) " + "VALUES (@name, @supplierid, @categoryid)", databaseConnection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@supplierid", supplierId);
            command.Parameters.AddWithValue("@categoryid", categoryId);
            command.ExecuteNonQuery();
        }
    }
}
