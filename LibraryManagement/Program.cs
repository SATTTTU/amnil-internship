using System;

namespace LibraryManagement
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                var library = new Library();

                library.AddBook(new Book("B101", "C# Basics", "John Doe"));
                library.AddBook(new Book("B102", "OOP Concepts", "Jane Smith"));
                library.AddBook(new Book("B103", "LINQ Deep Dive", "Alex Brown"));

                var s1 = new StudentMember("S01", "Alice");
                var f1 = new FacultyMember("F01", "Dr. Bob");

                library.RegisterMember(s1);
                library.RegisterMember(f1);

                library.BorrowBook(library.Books[0], s1);
                library.BorrowBook(library.Books[1], f1);
                library.ReturnBook(library.Books[0], s1);

                // View data
                library.ViewAllBooks();
                library.ViewMembers();
                library.ViewTransactions();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
            }
        }
    }
}
