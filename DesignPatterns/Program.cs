using DesignPatterns.HtmlBuilder;
using System.Text;

namespace EntryPoint
{
    public static class App
    {
        public static void Main()
        {
            HtmlBuilder html = new("html");
            HtmlBuilder ul = new("ul");

            html
                .AddChild(ul.Root);

            ul
                .AddChild("li", "hello")
                .AddChild("li", "world");

            Console.WriteLine(html.ToString());
        }
    }
}