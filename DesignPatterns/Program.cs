using DesignPatterns.Builder;
using DesignPatterns.HtmlBuilder;
using System.Text;

namespace EntryPoint
{
    public static class App
    {
        public static void Main()
        {

            Person yasser = Person.New
                .Called("Yasser")
                .WorkingAsA("SWE")
                .Build();

            Console.WriteLine(yasser.ToString());
        }
    }
}