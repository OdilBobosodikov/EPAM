namespace EPAM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input integer number - ");
            if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
            {
                Console.Write("Please input desired notation to convert (from 2 to 20) - ");
                if (int.TryParse(Console.ReadLine(), out int notation) && (notation >= 2 && notation <= 20))
                {
                    Console.WriteLine($"{number} (10) : {Converter(number, notation)} ({notation})");
                }
                else
                {
                    Console.WriteLine("invalid notation");
                }
            }
            else
            {
                Console.WriteLine("invalid number");
            }
        }
        protected static string Converter(int inpNumber, int notation)
        {
            if (notation == 10 || inpNumber == 0)
                return inpNumber.ToString();

            List<char> digits = new List<char>();

            var map = new Dictionary<int, char> {
            {1, '1'}, {2, '2'}, {3, '3'},
            {4, '4'}, {5, '5'}, {6, '6'},
            {7, '7'}, {8, '8'}, {9, '9'},
            {10, 'A'}, {11, 'B'}, {12, 'C'},
            {13, 'D'}, {14, 'E'}, {15, 'F'},
            {16, 'G'}, {17, 'H'}, {18, 'I'},
            {19, 'J'}, {0, '0'}
            };

            while (inpNumber > 0)
            {
                int digit = inpNumber % notation;
                digits.Add(map[digit]);
                inpNumber /= notation;
            }
            digits.Reverse();

            return string.Join(' ', digits);
        }
    }
}