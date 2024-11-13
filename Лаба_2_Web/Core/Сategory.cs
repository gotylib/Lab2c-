using System.ComponentModel.DataAnnotations;

public class Сategory
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public IList<Book> Books { get; set; }

    public Сategory(string name = "Null")
    {
        Name = name;
        Books = new List<Book>();
    }
}

