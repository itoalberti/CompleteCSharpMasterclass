namespace Classes;

// public: accessible from any other part of the program or other programs
// private: accessible only within the same class
// protected: accessible within the same class and by derived classes
// internal: can only be accessed from within the same assembly
internal class Book
{
    // MEMBER VARIABLE
    private string _title = "";
    private string _author = "";

    // PROPERTY
    public string Title
    {
			get=>title;
        set =>_title = value;
    }
    public string Author
    {
        get => _author;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("You must enter an author name");
                _author = "DEFAULTVALUE";
            }
            else
                _author = value;
        }
    }

    // CONSTRUCTOR
    public Book(string title, string author)
    {
        Title = title;
        Author = author;

        Console.WriteLine($"Book \"{Title}\" by {Author} has been created");
    }
}
