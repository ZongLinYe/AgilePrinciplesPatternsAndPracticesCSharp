using System;

namespace CH22_Template_Method_Practice
{

    internal class Program : FtoCTemplate
    {
        static void Main(string[] args)
        {
            new Program().FtoC();
        }
        public override void Init()
        {
            IsDone = false;
            Console.WriteLine("Fahrenheit to Celsius Conversion");
            Console.WriteLine("Please enter the Fahrenheit temperature:");
        }
        public override void MainFtoCMethod()
        {
            string fahrenheit = Console.ReadLine();
            // check if the user entered a number
            if (!double.TryParse(fahrenheit, out double fahrenheitDouble))
            {
                IsDone = true;
            }
            else
            {
                double celsius = (fahrenheitDouble - 32) * 5 / 9;
                Console.WriteLine($"The Celsius temperature is {celsius}");
            }
        }
        public override void EndPrint()
        {
            Console.WriteLine("ftoc Exit");
        }

    }
}
