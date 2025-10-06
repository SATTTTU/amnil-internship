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
        if (!IsAvailable)
        {
            Console.WriteLine($"{Title} is not available.");
            return;
        }

        IsAvailable = false;
        Console.WriteLine($"{Title} has been borrowed.");
    }

    public void ReturnBook()
    {
        if (IsAvailable)
        {
            Console.WriteLine($"{Title} was not borrowed.");
            return;
        }

        IsAvailable = true;
        Console.WriteLine($"{Title} has been returned.");
    }
}
