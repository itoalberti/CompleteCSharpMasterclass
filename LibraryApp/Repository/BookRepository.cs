using System.Globalization;
using LibraryApp.Model;
using static LibraryApp.Model.Book;

namespace LibraryApp.Repository
{
    public class BookRepository
    {
        private readonly List<Book> _allBooks = new();
        private int _nextId = 0;

        // ►►►►►►►►►►►►►►►►►►►►►►►►►► CREATE BOOK ◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄
        public Book CreateBook(Book newBook)
        {
            _nextId++;
            newBook.SetIdStatus(_nextId);
            _allBooks.Add(newBook);
            return newBook;
        }

        // ►►►►►►►►►►►►►►►►►►►►►►►►►► LIST ALL BOOKS ◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄
        public IReadOnlyList<Book> ListAllBooks() => _allBooks.AsReadOnly();

        // ►►►►►►►►►►►►►►►►►►►►►►►►►► GET BOOK BY ID ◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄
        public Book? GetBookById(int id) => _allBooks.FirstOrDefault(book => book.BookId == id);

        // ►►►►►►►►►►►►►►►►►►►►►►►►►► GET BOOKS BY AUTHOR ◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄
        public IReadOnlyList<Book>? GetBooksByAuthor(string author)
        {
            var compareInfo = CultureInfo.InvariantCulture.CompareInfo;
            return _allBooks
                .Where(book =>
                    compareInfo.IndexOf(
                        book.Author ?? string.Empty,
                        author.Trim(),
                        CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace
                    ) >= 0
                )
                .ToList();
        }

        // ►►►►►►►►►►►►►►►►►►►►►►►►►► GET BOOKS BY TITLE ◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄
        public IReadOnlyList<Book> GetBooksByTitle(string title)
        {
            var compareInfo = CultureInfo.InvariantCulture.CompareInfo;
            return _allBooks
                .Where(book =>
                    compareInfo.IndexOf(
                        book.Title,
                        title.Trim(),
                        CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace
                    ) >= 0
                )
                .ToList();
        }

        // ►►►►►►►►►►►►►►►►►►►►►►►►►► UPDATE BOOK STATUS ◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄
        public void UpdateBookStatus(Book bookToUpdate, BookStatus newStatus) =>
            bookToUpdate.UpdateBookStatus(newStatus);

        // ►►►►►►►►►►►►►►►►►►►►►►►►►► DELETE BOOK ◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄◄
        public void DeleteBook(Book book) => _allBooks.Remove(book);
    }
}
