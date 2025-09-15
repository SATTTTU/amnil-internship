namespace MyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Choose which assignment to run
            Console.WriteLine("Select Assignment ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Assignment1 a1 = new Assignment1();
                a1.Run(args);
            }
            else if (choice == "2")
            {
                Assignment2 a2 = new Assignment2();
                a2.Run(args);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}
