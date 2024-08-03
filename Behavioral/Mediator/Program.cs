
IChatRoomMediator chatRoom = new ChatRoom();

User user1 = new ConcreteUser(chatRoom, "Alice");
User user2 = new ConcreteUser(chatRoom, "Bob");
User user3 = new ConcreteUser(chatRoom, "Charlie");

chatRoom.AddUser(user1);
chatRoom.AddUser(user2);
chatRoom.AddUser(user3);

user1.Send("Hello everyone!");
user2.Send("Hi Alice!");

Console.ReadKey();

public abstract class User
{
    protected IChatRoomMediator _mediator;
    protected string _name;

    public User(IChatRoomMediator mediator, string name)
    {
        _mediator = mediator;
        _name = name;
    }

    public abstract void Send(string message);
    public abstract void Receive(string message);
}

public class ConcreteUser : User
{
    public ConcreteUser(IChatRoomMediator mediator, string name) : base(mediator, name) { }

    public override void Send(string message)
    {
        Console.WriteLine($"{_name} sends: {message}");
        _mediator.SendMessage(message, this);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"{_name} receives: {message}");
    }
}


public interface IChatRoomMediator
{
    void SendMessage(string message, User user);
    void AddUser(User user);
}

public class ChatRoom : IChatRoomMediator
{
    private List<User> _users = new List<User>();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void SendMessage(string message, User user)
    {
        foreach (var u in _users)
        {
            if (u != user)
            {
                u.Receive(message);
            }
        }
    }
}


