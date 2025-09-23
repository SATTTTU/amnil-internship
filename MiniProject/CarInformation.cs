using System;
namespace MiniProject
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public Car(string make, string model, int year, string color)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
        }

      public void Start()
        {
            Console.WriteLine($"{Year} {Make} {Model} is starting.");
        }

        public void Stop()
        {
            Console.WriteLine($"{Year} {Make} {Model} is stopping.");
        }
        public void Accelerate(int speed)
        {
            Console.WriteLine($"{Year} {Make} {Model} is accelerating to {speed} mph.");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Car Info: {Year} {Make} {Model}, Color: {Color}");
        }
    }
}