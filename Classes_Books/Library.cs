using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace LibrarySystem
{
    public class Library
    {
        // private List<Book> _collection = new List<Book>();
        private List<Book> _collection = new();

        public void AddBook()
        {
            Console.Write("\nBook title: ");
            string title = Console.ReadLine();
            Console.Write("Author: ");
            string author = Console.ReadLine();
            Console.Write("Publication year: ");
            int year = int.Parse(Console.ReadLine());
            Book book = new Book(title, author, year);
            _collection.Add(book);
            Console.WriteLine("\nBook added successfully!");
        }

        public void LendBook()
        {
            ListBooks();
            Console.Write($"\nChoose the book to lend: ");
            int index = int.Parse(Console.ReadLine());
            if (index > 0 && index <= _collection.Count && _collection[index - 1].IsAvailable)
            {
                _collection[index - 1].Lend();
                Console.WriteLine($"Book \"{_collection[index - 1].Title}\" lent successfully!");
            }
            else
            {
                Console.WriteLine($"Invalid option or book already lent");
            }
        }

        public void ReturnBook()
        {
            ListBooks();
            Console.Write("\nChoose the book to return: ");
            int index = int.Parse(Console.ReadLine());
            if (index > 0 && index <= _collection.Count && !_collection[index - 1].IsAvailable)
            {
                _collection[index - 1].Return();
                Console.WriteLine(
                    $"Book \"{_collection[index - 1].Title}\" returned successfully!"
                );
            }
            else
            {
                Console.WriteLine($"Invalid option or book already returned");
            }
        }

        public void ListBooks()
        {
            if (_collection.Count == 0)
            {
                Console.WriteLine($"===========================LIBRARY IS EMPTY===========================
                return;
            }
            else
            {
                Console.WriteLine($"\n===========================LIBRARY COLLECTION===========================
                for (int i = 0; i < _collection.Count; i++)
                    Console.WriteLine($"{i + 1, -3} | {_collection[i], -30}");
            }
        }

		// IEnumerable<T> → a sequence of T that I can iterate across
		public IEnumerable<Book> GetBooks()
		{
			return _collection;
		}
    }
}
