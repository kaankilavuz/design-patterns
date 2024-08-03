
BookCollection bookCollection = new BookCollection();
bookCollection.AddBook(new Book("1984", "George Orwell"));
bookCollection.AddBook(new Book("To Kill a Mockingbird", "Harper Lee"));
bookCollection.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald"));

IIterator<Book> iterator = bookCollection.CreateIterator();

while (iterator.HasNext())
{
    Book book = iterator.Next();
    Console.WriteLine(book);
}

Console.ReadKey();

public class Book
{
    public string Title { get; }
    public string Author { get; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public override string ToString()
    {
        return $"{Title} by {Author}";
    }
}


public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

public class BookIterator : IIterator<Book>
{
    private List<Book> _books;
    private int _position = 0;

    public BookIterator(List<Book> books)
    {
        _books = books;
    }

    public bool HasNext()
    {
        return _position < _books.Count;
    }

    public Book Next()
    {
        return _books[_position++];
    }
}

public class BookCollection : IAggregate<Book>
{
    private List<Book> _books = new List<Book>();

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public IIterator<Book> CreateIterator()
    {
        return new BookIterator(_books);
    }
}

