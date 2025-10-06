 using System;
 namespace LibraryManagement{
  public class Book
    {
        public string ISBN { get; }
        public string Title { get; }
        public string Author { get; }
        public bool IsAvailable { get; set; }

        public Book(string isbn, string title, string author)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            IsAvailable = true;
        }

        public override string ToString() => $"{Title} by {Author} (ISBN: {ISBN})";
    }
     public abstract class Member
    {
        public string MemberId { get; }
        public string Name { get; }
        public List<Book> BorrowedBooks { get; }

        protected Member(string memberId, string name)
        {
            MemberId = memberId;
            Name = name;
            BorrowedBooks = new List<Book>();
        }

        public abstract int BorrowLimit { get; }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{Name} (ID: {MemberId}) - Borrowed Books: {BorrowedBooks.Count}");
        }
    }
 }