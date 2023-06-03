namespace EF_Test3.Models;

public class Mark
{
    public int Id { get; set; }
    public virtual Student Student { get; set; }
    public virtual Subject Subject { get; set; }
    public int Grade { get; set; }
    public DateTime Date { get; set; }
}