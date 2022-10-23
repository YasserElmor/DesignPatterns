using DesignPatterns.Builder.Facade;

namespace EntryPoint
{
    public static class App
    {
        public static void Main()
        {

            PersonBuilderFacade pbf = new();

            Person yasser = pbf
                               .Works.At("Microsoft").AsA("SWE").Earning(5000)
                               .Lives.In("Port Said").At("Elzohour").WithPostCode("42614");

            
            Console.WriteLine(yasser.ToString());
        }
    }
}