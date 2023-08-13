namespace DesignPatterns.Behavioral.Observer;

class Program
{
    static void Main(string[] args)
    {
        NewsPublisher newsPublisher = new NewsPublisher();

        Subscriber subscriber1 = new Subscriber("Subscriber 1");
        Subscriber subscriber2 = new Subscriber("Subscriber 2");

        newsPublisher.Subscribe(subscriber1);
        newsPublisher.Subscribe(subscriber2);

        newsPublisher.PublishNews("New technology breakthrough!");
        Console.WriteLine();

        newsPublisher.Unsubscribe(subscriber1);

        newsPublisher.PublishNews("Weather forecast for the week.");

        Console.WriteLine("Hello, World!");
    }

    interface INewsObserver
    {
        void Observe(string news);
    }

    interface INewsSubject
    {
        void Subscribe(INewsObserver observe);
        void Unsubscribe(INewsObserver observe);
        void NotifySubscribers(string news);
    }

    class NewsPublisher : INewsSubject
    {
        private List<INewsObserver> observers = new List<INewsObserver>();
        private string latestNews;

        public void Subscribe(INewsObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(INewsObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifySubscribers(string news)
        {
            latestNews = news;
            foreach (var observer in observers)
            {
                observer.Observe(latestNews);
            }
        }

        public void PublishNews(string news)
        {
            Console.WriteLine($"Breaking news: {news}");
            NotifySubscribers(news);
        }
    }
    class Subscriber : INewsObserver
    {
        private string name;

        public Subscriber(string name)
        {
            this.name = name;
        }

        public void Observe(string news)
        {
            Console.WriteLine($"{name} received news: {news}");
        }
    }
}
