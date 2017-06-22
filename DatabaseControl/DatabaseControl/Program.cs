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
            //library.AddBook("Name 10", "Author 10", "Publisher 10", 1975);
            library.RemoveBook("Name 10");
        }
    }
}
