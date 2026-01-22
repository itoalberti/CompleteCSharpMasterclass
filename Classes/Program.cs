// using System.Globalization;


namespace Classes;

class Program
{
    static void Main(string[] args)
	{
		// used for transforming strings into Title Case
		// TextInfo textInfo=CultureInfo.CurrentCulture.TextInfo;

		Book lotr = new Book("The Lord of The Rings - The Fellowship of The Ring", "J. R. R. Tolkien");
		Console.WriteLine("Write below the name of the author:");
		// lotr.Author = Console.ReadLine();
		// lotr.Author=textInfo.ToTitleCase(lotr.Author);
		lotr.Author=Console.ReadLine();
		// lotr.Author = textInfo.ToTitleCase(lotr.Author);
		Console.WriteLine($"Author: {lotr.Author}");
    }
}
