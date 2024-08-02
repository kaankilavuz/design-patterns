
VehicleFactory carFactory = new CarFactory();
VehicleFactory motorcycleFactory = new MotorcycleFactory();

IVehicle car = carFactory.CreateVehicle();
IVehicle motor = motorcycleFactory.CreateVehicle();

car.Drive();
motor.Drive();

Console.ReadKey();

interface IVehicle
{
    void Drive();
}

class Car : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving car");
    }
}

class Motorcycle : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Driving motorcycle");
    }
}


abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();
}


class CarFactory : VehicleFactory
{
    public override IVehicle CreateVehicle()
    {
        return new Car();
    }
}

class MotorcycleFactory : VehicleFactory
{
    public override IVehicle CreateVehicle()
    {
        return new Motorcycle();
    }
}