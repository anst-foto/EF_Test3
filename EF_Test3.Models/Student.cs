namespace EF_Test3.Models;

public class Student
{
    public int Id { get; set; }
    public virtual Person Person { get; set; }
    public string Faculty { get; set; }

    public virtual List<Mark> Marks { get; set; }

    public override string ToString()
    {
        return $"{Person} - {Faculty}";
    }
}