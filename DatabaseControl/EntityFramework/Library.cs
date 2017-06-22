using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControl
{
    class Library
    {
        public void AddBook(string name, string author, string publisher, int year)
        {
            using (var context = new LibraryContext())
            {
                context.Books.Add(new Book
                {
                    Name = name,
                    Author = author,
                    Publisher = publisher,
                    Year = year
                });
                context.SaveChanges();
            }
        }

        public void RemoveBook(string name)
        {
            using (var context = new LibraryContext())
            {
                Book book = context.Books.FirstOrDefault(x => x.Name == name);
                if (book != null)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateBook(string name, string author, string publisher, int year)
        {
            using (var context = new LibraryContext())
            {
                Book book = context.Books.FirstOrDefault(x => x.Name == name);
                if (book != null)
                {
                    book.Author = author;
                    book.Publisher = publisher;
                    book.Year = year;
                    context.SaveChanges();
                }
            }
        }

        public void AddUser(string name, int age)
        {
            using (var context = new LibraryContext())
            {
                Console.WriteLine(context.Users.Count());
                var nameParam = new SqlParameter("@Name", name);
                var ageParam = new SqlParameter("@Age", age);
                var sql = @"INSERT INTO Users (Name, Age) VALUES ({0}, {1})";
                context.Database.ExecuteSqlCommand(sql, name, age);
                Console.WriteLine(context.Users.Count());
            }
        }

        public void RemoveUser(string name)
        {
            using (var context = new LibraryContext())
            {
                User user = context.Users.FirstOrDefault(x => x.Name == name);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        public List<Book> GetAllBooksOfUser(string name)
        {
            List<Book> books;
            using (var context = new LibraryContext())
            {
                int userId = context.Users.FirstOrDefault(x => x.Name == name).Id;
                books = context.Books.Where(x => x.UserId == userId).ToList();
            }
            return books;
        }

        public int GetBooksNumberOfAuthor(string name)
        {
            int booksNumber = 0;
            using (var context = new LibraryContext())
            {
                booksNumber = context.Books.Count(x => x.Author == name);
            }
            return booksNumber;
        }

        public Book GetBook(string name)
        {
            Book book;
            using (var context = new LibraryContext())
            {
                book = context.Books.FirstOrDefault(x => x.Name == name);
            }
            return book;
        }

        public void TakeBook (string bookName, string userName)
        {
            using (var context = new LibraryContext())
            {
                Book book = context.Books.FirstOrDefault(x => x.Name == bookName);
                User user = context.Users.FirstOrDefault(x => x.Name == userName);
                book.UserId = user.Id;
                user.Books.Add(book);
                context.SaveChanges();
            }
        }
        public void ReturnBook(string bookName)
        {
            using (var context = new LibraryContext())
            {
                
                Book book = context.Books.FirstOrDefault(x => x.Name == bookName);
                if (book.UserId != null)
                {
                    User user = context.Users.FirstOrDefault(x => x.Id == book.UserId);
                    book.UserId = null;
                    user.Books.Remove(book);
                    context.SaveChanges();
                }
            }
        }
    }
}
