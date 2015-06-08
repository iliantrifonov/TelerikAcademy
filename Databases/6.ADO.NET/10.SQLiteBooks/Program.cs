namespace _10.SQLiteBooks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SQLite;

    /// <summary>
    /// Re-implement the previous task with SQLite embedded DB (see http://sqlite.phxsoftware.com).
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            SQLiteConnection connection = new SQLiteConnection(@"Data Source=../../Library.db; Version=3;");
            AddBook("Some book", "Some author", "1111", "555-555-55", connection);
            FindBook("Some book", connection);
            ShowListOfAllBooks(connection);
        }

        public static void AddBook(string title, string author, string year, string ISBN, SQLiteConnection connection)
        {
            SQLiteCommand command = new SQLiteCommand("INSERT INTO books (title,author,publish_date,ISBN) VALUES (@title, @author, @year,@ISBN)", connection);
            connection.Open();
            using (connection)
            {
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@author", author);
                command.Parameters.AddWithValue("@year", year);
                command.Parameters.AddWithValue("@ISBN", ISBN);
                command.ExecuteNonQuery();
            }
        }

        public static void FindBook(string bookTitle, SQLiteConnection connection)
        {
            SQLiteCommand findCommand = new SQLiteCommand("SELECT author,title,publish_date FROM books WHERE title ='" + bookTitle + "';", connection);
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

        public static void ShowListOfAllBooks(SQLiteConnection connection)
        {
            SQLiteCommand command = new SQLiteCommand("SELECT title FROM books", connection);
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
