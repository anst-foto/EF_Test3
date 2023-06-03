using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Test3.Models;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }

    public virtual List<Student> Students { get; set; }

    [NotMapped]
    public string FullName => $"{LastName} {FirstName}";

    public override string ToString()
    {
        return $"{FullName} ({Phone})";
    }
}