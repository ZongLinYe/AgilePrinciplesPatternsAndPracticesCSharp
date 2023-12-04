using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH22_V2
{
    public class FtocTemplateMethod : Application
    {
        private TextReader input;
        private TextWriter outout;
        public static void Main(string[] args)
        {
            new FtocTemplateMethod().Run();
            Console.ReadKey();
        }
        protected override void Init()
        {
            input = Console.In;
            outout = Console.Out;
        }
        protected override void Idle()
        {
            string fahrString = input.ReadLine();
            if (string.IsNullOrEmpty(fahrString))
            {
                SetDone();
            }
            else
            {
                double fahr = double.Parse(fahrString);
                double celsius = 5.0 / 9.0 * (fahr - 32);
                outout.WriteLine($"F={fahr}, C={celsius}");
            }
        }
        protected override void Cleanup()
        {
            outout.WriteLine("ftoc exit");
        }


    }
}
