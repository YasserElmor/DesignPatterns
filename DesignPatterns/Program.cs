using DesignPatterns.Prototype;

namespace EntryPoint
{
    public static class App
    {
        public static void Main()
        {
            var John = new Person(new[] { "John", "Smith" }, new("London Road", 123));

            var Jane = John.DeepCopy();
            Jane.Names = new[] { "Jane", "Smith" };
            Jane.Address.HouseNumber = 321;
            Jane.Address.StreetName = "Milky Road";

            // Address: StreetName: London Road, HouseNumber: 123, Names: John Smith
            Console.WriteLine(John);
            // Address: StreetName: Milky Road, HouseNumber: 321, Names: Jane Smith
            Console.WriteLine(Jane);
        }

    }
}