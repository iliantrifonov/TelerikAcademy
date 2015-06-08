namespace _09.MySQLBooks
{
    using System;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench
    /// GUI administration tool . Create a MySQL database to store Books (title, author, publish date and ISBN). 
    /// Write methods for listing all books, finding a book by name and adding a book.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            var mySqlConn = new MySqlConnection(@"Server=localhost;Port=3306;Database=library;Uid=root;Pwd=f9a300eb;");
            AddBook("Some book", "Some author", "1111", "555-555-55", mySqlConn);
            FindBook("Some book", mySqlConn);
            ShowListOfAllBooks(mySqlConn);
        }

        public static void AddBook(string title, string author, string year, string ISBN, MySqlConnection mySqlConnection)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO books (title,author,publish_date,ISBN) VALUES (@title, @author, @year,@ISBN)", mySqlConnection);
            mySqlConnection.Open();
            using (mySqlConnection)
            {
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@author", author);
                command.Parameters.AddWithValue("@year", year);
                command.Parameters.AddWithValue("@ISBN", ISBN);
                command.ExecuteNonQuery();
            }
        }

        public static void FindBook(string bookTitle, MySqlConnection connection)
        {
            MySqlCommand findCommand = new MySqlCommand
            ("SELECT author,title,publish_date FROM books WHERE title ='" + bookTitle + "';", connection);
            connection.Open();
            using (connection)
            {
                var reader = findCommand.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string author = (string)reader["author"];
                        string title = (string)reader["title"];
                        int year = (int)reader["publish_date"];
                        Console.WriteLine("Author: {0}, Year: {1}, Title: {2}", author, year, title);
                    }
                }
            }
        }

        public static void ShowListOfAllBooks(MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand("SELECT title FROM books", connection);
            connection.Open();
            using (connection)
            {
                var reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string bookTitle = (string)reader["title"];
                        Console.WriteLine(bookTitle);
                    }
                }
            }
        }
    }
}