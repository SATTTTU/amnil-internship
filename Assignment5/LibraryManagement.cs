using System;
using System.Collections.Generic;

namespace Assignment5
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public Member(int id, string name)
        {
            Id = id;
            Name = name;
            BorrowedBooks = new List<Book>();
        }

        public void Borrow(Book book)
        {
            if (!book.IsAvailable)
            {
                Console.WriteLine($"Sorry, {book.Title} is not available.");
                return;
            }

            book.BorrowBook();
            BorrowedBooks.Add(book);
            Console.WriteLine($"{Name} borrowed {book.Title}.");
        }

        public void Return(Book book)
        {
            if (!BorrowedBooks.Contains(book))
            {
                Console.WriteLine($"{Name} did not borrow {book.Title}.");
                return;
            }

            book.ReturnBook();
            BorrowedBooks.Remove(book);
            Console.WriteLine($"{Name} returned {book.Title}.");
        }

        public void ShowBorrowedBooks()
        {
            Console.WriteLine($"\n{Name}'s borrowed books:");

            if (BorrowedBooks.Count == 0)
            {
                Console.WriteLine("No books borrowed.");
                return;
            }

            foreach (var book in BorrowedBooks)
            {
                Console.WriteLine(book);
            }
        }
    }
}
