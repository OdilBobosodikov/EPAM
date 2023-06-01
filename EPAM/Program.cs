using EPAM.Classes;

namespace EPAM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chose;
            CarSuply suply;
            while (true)
            {
                try
                {
                    CarCollection cars = CarCollection.Instance();
                    suply = CreateCarSuplyObject();
                    cars.AddCar(suply);

                    Console.Write("Would you like to add more car supplies? (type anything for yes) - ");
                    
                    if (Console.ReadLine() == "")
                    {
                        Console.WriteLine("What operation you want?");
                        Console.WriteLine("1 for CountTypes");
                        Console.Write("-- ");
                        chose = int.Parse(Console.ReadLine());

                        if(chose < 0 || chose > 4)
                        {
                            throw new FormatException();
                        }

                        if (chose == 1)
                        {
                            cars.SetCommand(new CountTypesCommand());
                            cars.CommandPerferm();
                        }                        
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Wrond input! Try again.\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Please choose commands from the list\n\n");
                }
            }
        }
        public static CarSuply CreateCarSuplyObject()
        {

            Console.Write("Please input manufacturing company - ");
            string companyName = Console.ReadLine();

            Validate(companyName);

            Console.Write("Please input car model - ");
            string model = Console.ReadLine();

            Validate(model);

            Console.Write("Please input quantity of cars - ");
            int quantity = int.Parse(Console.ReadLine());
            
            Console.Write("Please input price per item - ");
            double price = double.Parse(Console.ReadLine());

            return new CarSuply(companyName, model, quantity, price);
        }
        
        private static void Validate(string value) 
        {
            if(String.IsNullOrEmpty(value))
            {
                throw new FormatException();
            }
        }
    }
}