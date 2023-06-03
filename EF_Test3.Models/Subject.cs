namespace EF_Test3.Models;

public class Subject
{
    public int Id { get; set; }
    public string Title { get; set; }

    public virtual List<Mark> Marks { get; set; }
}