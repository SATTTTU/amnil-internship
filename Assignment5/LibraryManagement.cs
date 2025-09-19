using System;
using System.Collections.Generic;

namespace Assignment5
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }

        public Book(int id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
            IsAvailable = true;
        }

        public void BorrowBook()
        {
            if (IsAvailable)
            {
                IsAvailable = false;
                Console.WriteLine($"{Title} has been borrowed.");
            }
            else
            {
                Console.WriteLine($"{Title} is not available.");
            }
        }

        public void ReturnBook()
        {
            if (!IsAvailable)
            {
                IsAvailable = true;
                Console.WriteLine($"{Title} has been returned.");
            }
            else
            {
                Console.WriteLine($"{Title} was not borrowed.");
            }
        }

       
    }

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
            if (book.IsAvailable)
            {
                book.BorrowBook();
                BorrowedBooks.Add(book);
                Console.WriteLine($"{Name} borrowed {book.Title}.");
            }
            else
            {
                Console.WriteLine($"Sorry, {book.Title} is not available.");
            }
        }

        public void Return(Book book)
        {
            if (BorrowedBooks.Contains(book))
            {
                book.ReturnBook();
                BorrowedBooks.Remove(book);
                Console.WriteLine($"{Name} returned {book.Title}.");
            }
            else
            {
                Console.WriteLine($"{Name} did not borrow {book.Title}.");
            }
        }

        public void ShowBorrowedBooks()
        {
            Console.WriteLine($"\n{Name}'s borrowed books:");
            if (BorrowedBooks.Count == 0)
            {
                Console.WriteLine("No books borrowed.");
            }
            else
            {
                foreach (var book in BorrowedBooks)
                {
                    Console.WriteLine(book.ToString());
                }
            }
        }
    }
}