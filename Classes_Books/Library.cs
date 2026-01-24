// using System;
// using System.Collections.Generic;

namespace LibrarySystem
{
    public class Library
    {
        // private List<Book> _collection = new List<Book>();
        private readonly List<Book> _collection = new();

        public void AddBook(Book book)
        {
            _collection.Add(book);

            // Console.Write("\nBook title: ");
            // string title = Console.ReadLine();
            // Console.Write("Author: ");
            // string author = Console.ReadLine();
            // Console.Write("Publication year: ");
            // int year = int.Parse(Console.ReadLine());
            // _collection.Add(new Book(title, author, year));
            // Console.WriteLine("\nBook added successfully!");
        }

        public bool LendBook(int index)
        {
            // ListBooks();
            // Console.Write($"\nChoose the book to lend: ");
            // int index = int.Parse(Console.ReadLine()) - 1;
            // if (index >= 0 && index < _collection.Count && _collection[index].IsAvailable)
            // {
            //     _collection[index].Lend();
            //     Console.WriteLine($"Book \"{_collection[index].Title}\" lent successfully!");
            // }
            // else
            // {
            //     Console.WriteLine($"Invalid option or book already lent");
            // }
            if (!IsValidIndex(index) || !_collection[index].IsAvailable)
                return false;
            // if (!_collection[index].IsAvailable)
            //     return false;
            _collection[index].Lend();
            return true;
        }

        public bool ReturnBook(int index)
        {
            // ListBooks();
            // Console.Write("\nChoose the book to return: ");
            // int index = int.Parse(Console.ReadLine()) - 1;
            // if (index >= 0 && index < _collection.Count && !_collection[index].IsAvailable)
            // {
            //     _collection[index].Return();
            //     Console.WriteLine($"Book \"{_collection[index].Title}\" returned successfully!");
            // }
            // else
            // {
            //     Console.WriteLine($"Invalid option or book already returned");
            // }
            if (!IsValidIndex(index) || _collection[index].IsAvailable)
                return false;
            _collection[index].Return();
            return true;
        }

        // public IEnumerable<T> → a sequence of T that I can iterate across
        public IEnumerable<Book> GetBooks()
        {
            return _collection;
        }

        private bool IsValidIndex(int index)
        {
            return index >= 0 && index < _collection.Count;
        }

        // public void ListBooks()
        // {
        //     if (_collection.Count == 0)
        //     {
        //         Console.WriteLine(
        //             $"===========================LIBRARY IS EMPTY==========================="
        //         );

        //         return;
        //     }
        //     else
        //     {
        // Console.WriteLine(
        //     $"\n===========================LIBRARY COLLECTION==========================="
        // );

        // for (int i = 0; i < _collection.Count; i++)
        //     Console.WriteLine($"{i + 1, -3} | {_collection[i], -30}");
        //     }
        // }
    }
}
