
using System.ComponentModel.DataAnnotations;

public class Manager
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public int Age { get; set; }

    public DateTime CreatedAt { get; set; }

    public IList<User> Clients { get; set; }

    public Manager(DateTime createdAt, string name = "Null", string surname = "Null", int age = 0)
    {
        Name = name;
        Surname = surname;
        Age = age;
        CreatedAt = createdAt;
        Clients = new List<User>();
    }

}

