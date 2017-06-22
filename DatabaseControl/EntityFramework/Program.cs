using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControl
{
    class Program
    {
        private static Library library;
        static void Main(string[] args)
        {
            library = new Library();
            library.AddBook("Name 1", "Author 1", "Publisher 1", 1975);
            library.AddBook("Name 2", "Author 2", "Publisher 2", 1989);
            library.AddBook("Name 3", "Author 1", "Publisher 3", 2003);

            //library.RemoveBook("Name 2");

            //library.UpdateBook("Name 3", "Author 1", "Unknown", 2017);

            library.AddUser("Vaso", 34);
            library.AddUser("Ivan", 23);

            //library.RemoveUser("Ivan");

            //Console.WriteLine(library.GetBook("Name 3"));

            library.TakeBook("Name 3", "Vaso");
            library.ReturnBook("Name 3");

        }

    }
}
