using LibrarySystem;

Library collection = new();
int option = 0;

do
{
    Console.WriteLine("\n======LIBRARY MENU======");
    Console.WriteLine("1) Add a new book");
    Console.WriteLine("2) Lend a book");
    Console.WriteLine("3) Return a book");
    Console.WriteLine("4) List library collection");
    Console.WriteLine("0) Exit");
    Console.Write("Choose an option: ");
    option = int.Parse(Console.ReadLine());
    switch (option)
    {
        case 1:
            // ADD BOOK
            collection.AddBook();
            break;
        case 2:
            // LEND BOOK
            collection.LendBook();
            break;
        case 3:
            // RETURN BOOK
            collection.ReturnBook();
            break;
        case 4:
            // LIST BOOKS
            collection.ListBooks();
            break;
        case 0:
            // EXIT
            Console.WriteLine($"System closed");
            break;
    }
} while (option != 0);
