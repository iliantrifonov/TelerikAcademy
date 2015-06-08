namespace _08.ReadStringAndGiveProductsThatContainIt
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Write a program that reads a string from the console and finds
    /// all products that contain this string. Ensure you handle correctly 
    /// characters like ', %, ", \ and _.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "data source=HOME-PC;initial catalog=Northwind;integrated security=True;MultipleActiveResultSets=True;";
            SqlConnection databaseConnection = new SqlConnection(connectionString);
            databaseConnection.Open();
            var input = Console.ReadLine();

            string[] inputSeparator = input.Split(new char[] { '_', '\'', '%', '\"', '\\' });

            if (inputSeparator.Length > 1)
            {
                throw new ArgumentException("One or more of the symbols in your input are invalid and can cause SQL Injection");
            }

            using (databaseConnection)
            {
                var command = new SqlCommand("SELECT * FROM Products WHERE [ProductName] LIKE '%" + input + "%'", databaseConnection);
                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Product: {0}", reader["ProductName"]);
                    }
                }
            }
        }
    }
}
