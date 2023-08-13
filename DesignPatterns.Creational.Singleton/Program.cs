namespace DesignPatterns.Creational.Singleton;

class Program
{
    static void Main(string[] args)
    {

        var instance1 = Singleton.Instance;
        var instance2 = Singleton.Instance;

        Console.ReadKey();
    }

    sealed class Singleton
    {
        private static Singleton instance = null;

        private static readonly object lockObject = new();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                        instance = new Singleton();
                }

                return instance;
            }
        }
    }
}
