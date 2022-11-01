using DesignPatterns.Factory;

namespace EntryPoint
{
    public static class App
    {
        public static void Main()
        {
            var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);
        }
    }
}