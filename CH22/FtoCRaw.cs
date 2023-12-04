namespace CH22
{
    public class FtoCRaw
    {
        static void Main(string[] args)
        {
            bool done = false;
            while (done is false)
            {
                string fahrString = Console.ReadLine();

                if (string.IsNullOrEmpty(fahrString))
                {
                    done = true;
                }
                else
                {
                    double fahr = double.Parse(fahrString);
                    double celsius = 5.0 / 9.0 * (fahr - 32);
                    Console.WriteLine($"F={fahr}, C={celsius}");
                }
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
