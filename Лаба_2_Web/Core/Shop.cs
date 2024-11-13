
using System.ComponentModel.DataAnnotations;

public class Shop
{
    [Key]
    public int Id { get; set; }

    public string Address { get; set; }

    public IList<Book> Books { get; set; }

    public Shop(string address = "Null")
    {
        Address = address;
        Books = new List<Book>();
    }
}

