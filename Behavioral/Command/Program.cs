Light livingRoomLight = new Light();

LightOnCommand lightOn = new LightOnCommand(livingRoomLight);
LightOffCommand lightOff = new LightOffCommand(livingRoomLight);

RemoteControl remote = new RemoteControl();

remote.SetCommand(lightOn);
remote.PressButton();

remote.SetCommand(lightOff);
remote.PressButton();

remote.PressUndoButton();


Console.ReadKey();

public interface ICommand
{
    void Execute();
    void Undo();
}

public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("Light is OFF");
    }
}

public class LightOnCommand : ICommand
{
    private Light _light;

    public LightOnCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }

    public void Undo()
    {
        _light.TurnOff();
    }
}

public class LightOffCommand : ICommand
{
    private Light _light;

    public LightOffCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOff();
    }

    public void Undo()
    {
        _light.TurnOn();
    }
}

public class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }

    public void PressUndoButton()
    {
        _command.Undo();
    }
}
