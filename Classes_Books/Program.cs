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
            library.AddBook();
            break;
        case 2:
            library.LendBook();
            break;
        case 3:
            library.ReturnBook();
            break;
        case 4:
            library.ListBooks();
            break;
        case 0:
            Console.WriteLine("System closed");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (option != 0);
