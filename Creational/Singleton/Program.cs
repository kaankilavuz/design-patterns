Singleton singleton1 = Singleton.Instance;
Singleton singleton2 = Singleton.Instance;


if (singleton1.Equals(singleton2))
{
    Console.WriteLine("Equals");
}


Console.ReadKey();


class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new object();

    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }
    }
}