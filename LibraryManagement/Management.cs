using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement
{
    public interface IBorrowable
    {
        void BorrowBook(Book book, Member member);
        void ReturnBook(Book book, Member member);
    }

  
   

    public class StudentMember : Member
    {
        public StudentMember(string memberId, string name) : base(memberId, name) { }
        public override int BorrowLimit => 3;
    }

    public class FacultyMember : Member
    {
        public FacultyMember(string memberId, string name) : base(memberId, name) { }
        public override int BorrowLimit => 5;
    }

    public class Transaction
    {
        public string TransactionId { get; }
        public string MemberId { get; }
        public string ISBN { get; }
        public string Type { get; } 
        public DateTime Date { get; }

        public Transaction(string memberId, string isbn, string type)
        {
            TransactionId = Guid.NewGuid().ToString();
            MemberId = memberId;
            ISBN = isbn;
            Type = type;
            Date = DateTime.Now;
        }

        public override string ToString() => $"{Date}: {Type} - ISBN {ISBN} by Member {MemberId}";
    }

    public class Library : IBorrowable
    {
        public List<Book> Books { get; }
        public List<Member> Members { get; }
        public List<Transaction> Transactions { get; }

        public Library()
        {
            Books = new List<Book>();
            Members = new List<Member>();
            Transactions = new List<Transaction>();
        }

        public void AddBook(Book book)
        {
            if (Books.Any(b => b.ISBN == book.ISBN))
                throw new Exception("Book with this ISBN already exists.");

            Books.Add(book);
            Console.WriteLine($" Book added: {book}");
        }

        public void RemoveBook(string isbn)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null) throw new Exception("Book not found.");

            Books.Remove(book);
            Console.WriteLine($" Book removed: {book.Title}");
        }

        public void RegisterMember(Member member)
        {
            if (Members.Any(m => m.MemberId == member.MemberId))
                throw new Exception("Member with this ID already exists.");

            Members.Add(member);
            Console.WriteLine($" Member registered: {member.Name}");
        }

        public void BorrowBook(Book book, Member member)
        {
            if (!book.IsAvailable)
                throw new Exception("Book is currently unavailable.");

            if (member.BorrowedBooks.Count >= member.BorrowLimit)
                throw new Exception($"{member.Name} has reached their borrowing limit.");

            book.IsAvailable = false;
            member.BorrowedBooks.Add(book);
            Transactions.Add(new Transaction(member.MemberId, book.ISBN, "Borrow"));
            Console.WriteLine($" {member.Name} borrowed '{book.Title}'.");
        }

        public void ReturnBook(Book book, Member member)
        {
            if (!member.BorrowedBooks.Contains(book))
                throw new Exception("This book was not borrowed by the member.");

            book.IsAvailable = true;
            member.BorrowedBooks.Remove(book);
            Transactions.Add(new Transaction(member.MemberId, book.ISBN, "Return"));
            Console.WriteLine($" {member.Name} returned '{book.Title}'.");
        }

        public void ViewAllBooks()
        {
            Console.WriteLine("\nLibrary Books:");
            Books.ForEach(b => Console.WriteLine($"{b.Title} - {(b.IsAvailable ? "Available" : "Borrowed")}"));
        }

        public void ViewMembers()
        {
            Console.WriteLine("\n Registered Members:");
            Members.ForEach(m => m.DisplayInfo());
        }

        public void ViewTransactions()
        {
            Console.WriteLine("\n Transactions:");
            Transactions.ForEach(t => Console.WriteLine(t));
        }
    }

    
}
