
Report originalReport = new Report
{
    Title = "Annual Report",
    Content = "This is the content of the annual report.",
    Pages = 100
};

Report clonedReport = (Report)originalReport.Clone();
clonedReport.Title = "Cloned Annual Report";

Thesis originalThesis = new Thesis
{
    Title = "Master Thesis",
    Author = "John Doe",
    Pages = 150
};

Thesis clonedThesis = (Thesis)originalThesis.Clone();
clonedThesis.Title = "Cloned Master Thesis";

originalReport.PrintDetails();
clonedReport.PrintDetails();
originalThesis.PrintDetails();
clonedThesis.PrintDetails();

Console.ReadKey();


interface IDocument
{
    IDocument Clone();
    void PrintDetails();
}

class Report : IDocument
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Pages { get; set; }

    public IDocument Clone()
    {
        return (IDocument)this.MemberwiseClone();
    }

    public void PrintDetails()
    {
        Console.WriteLine($"Report: {Title}, Pages: {Pages}, Content: {Content}");
    }
}

class Thesis : IDocument
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Pages { get; set; }

    public IDocument Clone()
    {
        return (IDocument)this.MemberwiseClone();
    }

    public void PrintDetails()
    {
        Console.WriteLine($"Thesis: {Title}, Author: {Author}, Pages: {Pages}");
    }
}

