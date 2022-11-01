namespace DesignPatterns.Factory
{
    public class Point
    {
        private double _x, _y;

        private Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            static string Format(string str)
            {
                string trimmedStr = str.Trim('_');
                string initial = string.Join("", trimmedStr.Take(1)).ToUpper();
                string rest = string.Join("", trimmedStr.Skip(1));
                string name = initial + rest;

                return name;
            }

            string x = Format(nameof(_x));
            string y = Format(nameof(_y));


            return $"{x}: {_x}, {y}: {_y}";
        }

        public static class Factory
        {

            // CartesianPoint construction factory method
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            // CartesianPoint construction factory method
            public static Point NewPolarPoint(double rho, double theta)
            {
                double x = rho * Math.Cos(theta);
                double y = rho * Math.Sin(theta);

                return new Point(x, y);
            }
        }

    }
}
