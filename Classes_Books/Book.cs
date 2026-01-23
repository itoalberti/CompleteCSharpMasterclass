namespace LibrarySystem
{
    public class Book
    {
        // "set" is only available at constructor. Properties are read=-only
        public string Title { get; }
        public string Author { get; }
        public int Year { get; }
        public bool IsAvailable { get; private set; }

        // ============= CONSTRUCTOR =============
        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
            IsAvailable = true;
        }

        // ============= METHODS =============
        public void Lend()
        {
            IsAvailable = false;
        }

        public void Return()
        {
            IsAvailable = true;
        }

        public override string ToString()
        {
            string status = IsAvailable ? "[Available]" : "[Borrowed]";
            return $"{status, -11} | {Title, -40} | {Author, -25} | {(Year)}";
        }
    }
}
