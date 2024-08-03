Door door = new Door();
door.Open();
door.Lock();
door.Close();
door.Lock();
door.Open();
door.Unlock();
door.Open();

Console.ReadKey();


public class Door
{
    private IDoorState _currentState;

    public Door()
    {
        _currentState = new ClosedState();
    }

    public void SetState(IDoorState state)
    {
        _currentState = state;
    }

    public void Open()
    {
        _currentState.Open(this);
    }

    public void Close()
    {
        _currentState.Close(this);
    }

    public void Lock()
    {
        _currentState.Lock(this);
    }

    public void Unlock()
    {
        _currentState.Unlock(this);
    }
}

public class OpenState : IDoorState
{
    public void Open(Door door)
    {
        Console.WriteLine("The door is already open.");
    }

    public void Close(Door door)
    {
        Console.WriteLine("Closing the door.");
        door.SetState(new ClosedState());
    }

    public void Lock(Door door)
    {
        Console.WriteLine("Cannot lock the door while it's open.");
    }

    public void Unlock(Door door)
    {
        Console.WriteLine("The door is already unlocked.");
    }
}

public class ClosedState : IDoorState
{
    public void Open(Door door)
    {
        Console.WriteLine("Opening the door.");
        door.SetState(new OpenState());
    }

    public void Close(Door door)
    {
        Console.WriteLine("The door is already closed.");
    }

    public void Lock(Door door)
    {
        Console.WriteLine("Locking the door.");
        door.SetState(new LockedState());
    }

    public void Unlock(Door door)
    {
        Console.WriteLine("The door is already unlocked.");
    }
}

public class LockedState : IDoorState
{
    public void Open(Door door)
    {
        Console.WriteLine("Cannot open the door. It's locked.");
    }

    public void Close(Door door)
    {
        Console.WriteLine("The door is already closed and locked.");
    }

    public void Lock(Door door)
    {
        Console.WriteLine("The door is already locked.");
    }

    public void Unlock(Door door)
    {
        Console.WriteLine("Unlocking the door.");
        door.SetState(new ClosedState());
    }
}


public interface IDoorState
{
    void Open(Door door);
    void Close(Door door);
    void Lock(Door door);
    void Unlock(Door door);
}
