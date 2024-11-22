public class Reference
{
    public string Book { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndVerse { get; private set; }
    
    public Reference(string book, int startVerse, int? endVerse = null)
    {
        Book = book;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return EndVerse == null ? $"{Book} {StartVerse}" : $"{Book} {StartVerse}-{EndVerse}";
    }
}
