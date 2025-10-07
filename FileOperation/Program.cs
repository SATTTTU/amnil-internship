using System;
namespace FileOperation
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the path of the text file: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            LogFileWriter logger = new LogFileWriter();
            TextFileProcessor processor = new TextFileProcessor(filePath, logger);

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Count lines, words, and characters");
                Console.WriteLine("2. Create a backup");
                Console.WriteLine("3. Search for text");
                Console.WriteLine("4. Exit");

                Console.Write("Your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        processor.CountContents();
                        break;
                    case "2":
                        processor.CreateBackup();
                        break;
                    case "3":
                        Console.Write("Enter text to search: ");
                        string searchText = Console.ReadLine();
                        processor.SearchText(searchText);
                        break;
                    case "4":
                        Console.WriteLine("Exiting.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}