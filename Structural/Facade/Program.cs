HomeFacade homeFacade = new HomeFacade();
homeFacade.EnterHome();
homeFacade.LeaveHome();

Console.ReadKey();

class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Lights are turned on.");
    }

    public void TurnOff()
    {
        Console.WriteLine("Lights are turned off.");
    }
}

class AirConditioner
{
    public void TurnOn()
    {
        Console.WriteLine("Air conditioner is turned on.");
    }

    public void TurnOff()
    {
        Console.WriteLine("Air conditioner is turned off.");
    }

    public void SetTemperature(int temperature)
    {
        Console.WriteLine($"Temperature is set to {temperature} degrees.");
    }
}

class SecuritySystem
{
    public void Arm()
    {
        Console.WriteLine("Security system is armed.");
    }

    public void Disarm()
    {
        Console.WriteLine("Security system is disarmed.");
    }
}

class HomeFacade
{
    private Light _light;
    private AirConditioner _airConditioner;
    private SecuritySystem _securitySystem;

    public HomeFacade()
    {
        _light = new Light();
        _airConditioner = new AirConditioner();
        _securitySystem = new SecuritySystem();
    }

    public void EnterHome()
    {
        Console.WriteLine("Entering home...");
        _light.TurnOn();
        _airConditioner.TurnOn();
        _airConditioner.SetTemperature(24);
        _securitySystem.Disarm();
    }

    public void LeaveHome()
    {
        Console.WriteLine("Leaving home...");
        _light.TurnOff();
        _airConditioner.TurnOff();
        _securitySystem.Arm();
    }
}

