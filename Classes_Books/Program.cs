using LibrarySystem;

Library library = new();
int option;

do
{
    Console.WriteLine("\n======LIBRARY MENU======");
    Console.WriteLine("1) Add a new book");
    Console.WriteLine("2) Lend a book");
    Console.WriteLine("3) Return a book");
    Console.WriteLine("4) List library collection");
    Console.WriteLine("0) Exit");
    Console.Write("Choose an option: ");

    if (!int.TryParse(Console.ReadLine(), out option))
    {
        Console.WriteLine("Invalid option! Choose again");
        continue;
    }
    switch (option)
    {
        case 1:
            AddBook(library);
            break;
        case 2:
            LendBook(library);
            break;
        case 3:
            ReturnBook(library);
            break;
        case 4:
            ListBooks(library);
            break;
        case 0:
            Console.WriteLine("System closed");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (option != 0);

// ========================HELPER METHODS========================
void AddBook(Library library)
{
    Console.Write($"Book title: ");
    string title = Console.ReadLine();
    Console.Write($"Author: ");
    string author = Console.ReadLine();
    Console.Write($"Publication year: ");
    if (!int.TryParse(Console.ReadLine(), out int year))
    {
        Console.Write($"Invalid year.");
        return;
    }
    library.AddBook(new Book(title, author, year));
    Console.WriteLine($"Book \"{title}\" added successfully!");
}

void LendBook(Library library)
{
    ListBooks(library);
    Console.Write($"\nChoose the book to lend: ");
    if (!int.TryParse(Console.ReadLine(), out int index))
    {
        Console.WriteLine($"Invalid option or book already lent");
        return;
    }
    else
    {
        library.LendBook(index - 1);
        Console.WriteLine($"Book lent successfully!");
    }
}
void ReturnBook(Library library)
{
    ListBooks(library);
    Console.Write($"\nChoose the book to return: ");
    if (int.TryParse(Console.ReadLine(), out int index))
    {
        library.ReturnBook(index - 1);
        Console.WriteLine($"Book returned successfully!");
    }
    else
    {
        Console.WriteLine($"Invalid option or book already returned");
        return;
    }
}
void ListBooks(Library library)
{
    var books = library.GetBooks();
    if (!books.Any())
    {
        Console.WriteLine($"Library is empty");
        return;
    }
    Console.WriteLine(
        $"\n===========================LIBRARY COLLECTION==========================="
    );
    int i = 1;
    foreach (var book in books)
    {
        Console.WriteLine(
            $"{i++, -3} | {(book.IsAvailable ? "Available" : "Borrowed"), -10} | {book.Title, -30} | {book.Author} ({book.Year})"
        );
    }
}
