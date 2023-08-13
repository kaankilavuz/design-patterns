namespace DesignPatterns.Behavioral.Command;

class Program
{
    static void Main(string[] args)
    {
        ICommand turnOnCommand = new TurnOnLightCommand();
        ICommand turnOfCommand = new TurnOffLightCommand();

        turnOnCommand.Execute();
        turnOfCommand.Execute();

        Console.ReadKey();
    }


    interface ICommand
    {
        void Execute();
    }

    class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("turned on");
        }

        public void TurnOff()
        {
            Console.WriteLine("turned off");
        }
    }

    class TurnOnLightCommand : ICommand
    {
        Light light;
        public TurnOnLightCommand()
        {
            light = new Light();
        }
        public void Execute()
        {
            light.TurnOn();
        }
    }

    class TurnOffLightCommand : ICommand
    {
        Light light;
        public TurnOffLightCommand()
        {
            light = new Light();
        }
        public void Execute()
        {
            light.TurnOff();
        }
    }
}
