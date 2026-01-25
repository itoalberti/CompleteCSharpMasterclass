namespace LibrarySystem
{
    public class Library
    {
        // private List<Book> _collection = new List<Book>();
        private readonly List<Book> _collection = new();

        public void AddBook()
        {
            // _collection.Add(book);
            Console.Write("\nBook title: ");
            string title = Console.ReadLine();
            Console.Write("Author: ");
            string author = Console.ReadLine();
            Console.Write("Publication year: ");
            int year = int.Parse(Console.ReadLine());
            _collection.Add(new Book(title, author, year));
            Console.WriteLine("\nBook added successfully!");
        }

        public void LendBook()
        {
            if (!_collection.Any())
            {
                ListBooks();
                return;
            }
            ListBooks();
            Console.Write($"\nChoose the book to lend: ");
            int index = int.Parse(Console.ReadLine());
            if (index > 0 && index <= _collection.Count && _collection[index - 1].IsAvailable)
            {
                _collection[index - 1].Lend();
                Console.WriteLine($"Book \"{_collection[index - 1].Title}\" lent successfully!");
            }
            else
                Console.WriteLine($"Invalid option or book already lent");
        }

        public void ReturnBook()
        {
            if (!_collection.Any())
            {
                ListBooks();
                return;
            }
            ListBooks();
            Console.Write($"\nChoose the book to return: ");
            int index = int.Parse(Console.ReadLine());
            if (index > 0 && index <= _collection.Count && !_collection[index - 1].IsAvailable)
            {
                _collection[index - 1].Return();
                Console.WriteLine(
                    $"Book \"{_collection[index - 1].Title}\" returned successfully!"
                );
            }
            else
                Console.WriteLine($"Invalid option or book already returned");
        }

        // public IEnumerable<T> → a sequence of T that I can iterate across
        public IEnumerable<Book> GetBooks() => _collection;

        public void ListBooks()
        {
            if (_collection.Count == 0)
            {
                Console.WriteLine(
                    $"========================================LIBRARY IS EMPTY========================================"
                );
                return;
            }
            else
            {
                Console.WriteLine(
                    $"\n=======================================LIBRARY COLLECTION======================================="
                );

                for (int i = 0; i < _collection.Count; i++)
                    Console.WriteLine($"{i + 1, -3} | {_collection[i], -30}");
            }
        }
    }
}
