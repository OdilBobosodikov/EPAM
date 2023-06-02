using EPAM.Classes;
using EPAM.Classes.Commands;
using EPAM.Interfaces;

namespace EPAM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isReadyToTakeCommands = false;
            CarSuply carSuply;
            while (true)
            {
                try
                {
                    CarCollection cars = CarCollection.Instance();
                    if (!isReadyToTakeCommands)
                    {
                        Console.WriteLine("Enter car suply properties (brand, model, quantity, unit price):");
                        string[] userInput = Console.ReadLine().Split(' ');

                        if (userInput.Length != 4)
                        {
                            Console.WriteLine("Please input 4 fields.\n");
                            continue;
                        }

                        string brand = userInput[0].Trim();
                        string model = userInput[1].Trim();
                        int quantity = int.Parse(userInput[2].Trim());
                        decimal price = decimal.Parse(userInput[3].Trim());

                        carSuply = new CarSuply()
                        {
                            Brand = brand,
                            CarModel = model,
                            Quantity = quantity,
                            PricePerItem = price
                        };

                        cars.AddCarSuply(carSuply);
                    }

                    isReadyToTakeCommands = isReadyToTakeCommands == false ? EnoughCars() : true;
                    if (isReadyToTakeCommands)
                    {
                        Console.Write("Choose command. Available commands are: \ncount types, count all, average price, average price type, exit - ");
                        string command = Console.ReadLine().Trim();

                        if (command.Trim().Equals("count types"))
                        {
                            cars.SetCommand(new CountTypesCommand());
                        }
                        else if (command.Trim().Equals("count all"))
                        {
                            cars.SetCommand(new CountAllCommand());
                        }
                        else if (command.Trim().Equals("average price"))
                        {
                            cars.SetCommand(new AveragePriceCommand());
                        }
                        else if (command.Trim().StartsWith("average price"))
                        {
                            string brandName = command.Split(' ')[2];
                            cars.SetCommand(new AveragePriceTypeCommand(), brandName);
                        }
                        else if (command.Trim().Equals("exit"))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("There is no such a command.\n");
                            continue;
                        }
                        cars.CommandPerferm();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrond input! Try again.\n");
                }
            }
        }
        internal static bool EnoughCars()
        {
            Console.Write("Would you like to stop adding car supplies? (type anything for yes) - ");
            if (String.IsNullOrEmpty(Console.ReadLine()))
            {
                return false;
            }
            return true;
        }
    }
}