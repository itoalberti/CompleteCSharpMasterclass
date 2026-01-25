namespace LibrarySystem
{
    public class Book
    {
        // "set" is only available at constructor. Properties are read=-only
        private static int nextId = 0;
        public int ID;
        public string Title { get; }
        public string Author { get; }
        public int Year { get; }
        public bool IsAvailable { get; private set; } = true;

        // ============= CONSTRUCTOR =============
        public Book(string title, string author, int year)
        {
            ID = nextId++;
            Title = title;
            Author = author;
            Year = year;
        }

        // ============= METHODS =============
        public void Lend() => IsAvailable = false;

        public void Return() => IsAvailable = true;

        public void GetDetails()
        {
            Console.WriteLine($"Book ID: {ID}\nBook title: {Title}\nAuthor: {Author}");
        }

        public override string ToString()
        {
            string status = IsAvailable ? "[Available]" : "[Borrowed]";
            return $"{status, -11} | {Title, -40} | {Author, -25} | {(Year)}";
        }
    }
}
