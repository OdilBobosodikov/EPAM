namespace EPAM.Structures
{
    internal struct Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Coordinate(double x, double y, double z)
        {
            HasNegativeNumber(x, y, z);
            X = x; Y = y; Z = z;
        }

        private static void HasNegativeNumber(params double[] coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                if(coordinate < 0)
                {
                    throw new ArgumentException();
                }
            }
        }


        public override string ToString()
        {
            return $"({X} : {Y} : {Z})";
        }
    }
}
