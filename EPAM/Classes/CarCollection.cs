using EPAM.Interfaces;

namespace EPAM.Classes
{
    internal sealed class CarCollection
    {
        public List<CarSuply> Cars = new List<CarSuply>();
        private static CarCollection? instance;
        public string BrandName { get; private set; }
        private IOrder? Command;

        private CarCollection(){}

        public static CarCollection Instance()
        {
            if(instance == null)
            {
                instance = new CarCollection();
            }
            return instance;
        }

        public void SetCommand(IOrder command, string? brandName = null)
        {
            if (brandName != null)
            {
                BrandName = brandName;
            }
            Command = command;
        }

        public void AddCarSuply(CarSuply car)
        {
            Cars.Add(car);
        }

        public void CommandPerferm()
        {
            if(Command is IOrder)
            {
                Command.Execute(this);
            }
        }
    }
}
