using System;
namespace Refactor
{

    class Refactor2
    {
        static double CelciusToFahrenheit(double celcius)
        {
            return (celcius * 9 / 5) + 32;
        }
        static double FahrenheitToCelcius(double farhenheit)
        {
            return (farhenheit - 32) * 5 / 9;
        }
        static double CelciusToKelvin(double celcius)
        {
            return celcius + 273.15;
        }
        static double KelvinToCelcius(double kelvin)
        {
            return kelvin - 273.15;
        }
        static double FahrenheitToKelvin(double farhenheit)
        {
            return (farhenheit - 32) * 5 / 9 + 273.15;
        }
        public void DisplayResult(double celcius, double farhenheit, double kelvin)
        {
            Console.WriteLine("Celcius to Farhenheit: " + CelciusToFahrenheit(celcius));
            Console.WriteLine("Farhenheit to Celcius: " + FahrenheitToCelcius(farhenheit));
            Console.WriteLine("Celcius to Kelvin: " + CelciusToKelvin(celcius));
            Console.WriteLine("Kelvin to Celcius: " + KelvinToCelcius(kelvin));
            Console.WriteLine("Farhenheit to Kelvin: " + FahrenheitToKelvin(farhenheit));
        }


    }
}