
using System.Data.Common;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string FilePath { get; set; }

    public string СoverPath { get; set; }

    public IList<User> Readers { get; set; }

    public IList<Сategory> Categories { get; set; }

    public IList<Shop>  Shops { get; set; }

    public Book(string title = "Null", string author = "Null", string filePath = "Null", string сoverPath = "Null")
    {
        Title = title;
        Author = author;
        FilePath = filePath;
        СoverPath = сoverPath;
        Readers = new List<User>();
        Categories = new List<Сategory>();
        Shops = new List<Shop>();   
    }
}


