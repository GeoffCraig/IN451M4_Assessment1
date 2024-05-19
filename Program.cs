namespace IN451M4_Assessment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Scenario scenario1 = new Scenario(3, 10);
            scenario1.Run();
            scenario1.OutputResults();

            Scenario scenario2 = new Scenario(5, 20);
            scenario2.Run();
            scenario2.OutputResults();

            Scenario scenario3 = new Scenario(5, 30);
            scenario3.Run();
            scenario3.OutputResults();
        }
    }
}
