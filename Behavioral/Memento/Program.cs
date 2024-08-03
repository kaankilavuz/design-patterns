TextEditor editor = new TextEditor();
TextEditorHistory history = new TextEditorHistory();

editor.SetText("First Version");
history.SaveState(editor.Save());

editor.SetText("Second Version");
history.SaveState(editor.Save());

editor.SetText("Third Version");

editor.Restore(history.Undo());
editor.Restore(history.Undo());

Console.ReadKey();

public class TextMemento
{
    public string Text { get; private set; }

    public TextMemento(string text)
    {
        Text = text;
    }
}


public class TextEditor
{
    private string _text;

    public void SetText(string text)
    {
        _text = text;
        Console.WriteLine($"Text set to: {_text}");
    }

    public TextMemento Save()
    {
        return new TextMemento(_text);
    }

    public void Restore(TextMemento memento)
    {
        _text = memento.Text;
        Console.WriteLine($"Text restored to: {_text}");
    }
}


public class TextEditorHistory
{
    private Stack<TextMemento> _history = new Stack<TextMemento>();

    public void SaveState(TextMemento memento)
    {
        _history.Push(memento);
    }

    public TextMemento Undo()
    {
        if (_history.Count > 0)
        {
            return _history.Pop();
        }
        return null;
    }
}
