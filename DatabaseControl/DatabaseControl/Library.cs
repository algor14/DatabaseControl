using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DatabaseControl
{
    class Library
    {
        private List<User> users;
        private List<Book> books;
        public Library()
        {
            users = new List<User>();
            books = new List<Book>();
        }
        public void AddBook(string name, string author, string publisher, int year)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["LibraryDefault"].ConnectionString;
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO Books(Name, Author, Publisher, Year) VALUES
			                                            (@Name, @Author, @Publisher, @Year)";

                    var nameParam = new SqlParameter("@Name", name);
                    var authorParam = new SqlParameter("@Author", author);
                    var publisherParam = new SqlParameter("@Publisher", publisher);
                    var yearParam = new SqlParameter("@Year", year);

                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(authorParam);
                    command.Parameters.Add(publisherParam);
                    command.Parameters.Add(yearParam);

                    command.ExecuteNonQuery();                    
                }
            }
        }

        public void RemoveBook(string name)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["LibraryDefault"].ConnectionString;
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"DELETE FROM Books WHERE Name = @Name";

                    var nameParam = new SqlParameter("@Name", name);
                    command.Parameters.Add(nameParam);

                    if(command.ExecuteNonQuery() > 0)
                        Console.WriteLine("Book was deleted");
                    else
                        Console.WriteLine("Couldn't find this book");
                }
            }
        }
    }
}
