using EPAM.Interfaces;

namespace EPAM.Classes
{
    internal sealed class CarCollection
    {
        public List<CarSuply> Cars = new List<CarSuply>();
        private static CarCollection? instance;

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

        public void SetCommand(IOrder command)
        {
            Command = command;
        }

        public void AddCar(CarSuply car)
        {
            Cars.Add(car);
        }

        public void CommandPerferm()
        {
            if(Command is IOrder && Command != null)
            {
                Command.Execute(Cars);
                Command = null;
            }
        }
    }
}
