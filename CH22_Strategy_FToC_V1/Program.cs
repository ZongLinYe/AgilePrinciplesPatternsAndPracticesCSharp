namespace CH22_Strategy_FToC_V1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IApplication application = new FToCStrategy();
            ApplicationRunner runner = new ApplicationRunner(application);
            runner.Run();
        }
    }
}
