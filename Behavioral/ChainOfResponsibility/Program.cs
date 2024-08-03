SupportHandler basicSupport = new BasicSupportHandler();
SupportHandler advancedSupport = new AdvancedSupportHandler();
SupportHandler expertSupport = new ExpertSupportHandler();

basicSupport.SetNextHandler(advancedSupport);
advancedSupport.SetNextHandler(expertSupport);


SupportTicket ticket1 = new SupportTicket(1, "Password reset");
SupportTicket ticket2 = new SupportTicket(2, "Software installation");
SupportTicket ticket3 = new SupportTicket(3, "System crash");
SupportTicket ticket4 = new SupportTicket(4, "Network issue");


basicSupport.HandleRequest(ticket1);
basicSupport.HandleRequest(ticket2);
basicSupport.HandleRequest(ticket3);
basicSupport.HandleRequest(ticket4);

Console.ReadKey();


public abstract class SupportHandler
{
    protected SupportHandler _nextHandler;

    public void SetNextHandler(SupportHandler nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public abstract void HandleRequest(SupportTicket ticket);
}

public class SupportTicket
{
    public int Level { get; }
    public string Description { get; }

    public SupportTicket(int level, string description)
    {
        Level = level;
        Description = description;
    }
}

public class BasicSupportHandler : SupportHandler
{
    public override void HandleRequest(SupportTicket ticket)
    {
        if (ticket.Level <= 1)
        {
            Console.WriteLine($"Basic Support Handler: Handling ticket '{ticket.Description}'");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(ticket);
        }
    }
}

public class AdvancedSupportHandler : SupportHandler
{
    public override void HandleRequest(SupportTicket ticket)
    {
        if (ticket.Level <= 2)
        {
            Console.WriteLine($"Advanced Support Handler: Handling ticket '{ticket.Description}'");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(ticket);
        }
    }
}

public class ExpertSupportHandler : SupportHandler
{
    public override void HandleRequest(SupportTicket ticket)
    {
        if (ticket.Level <= 3)
        {
            Console.WriteLine($"Expert Support Handler: Handling ticket '{ticket.Description}'");
        }
        else
        {
            Console.WriteLine($"Ticket '{ticket.Description}' could not be handled.");
        }
    }
}

