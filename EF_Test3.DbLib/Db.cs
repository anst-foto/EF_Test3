using EF_Test3.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Test3.DbLib;

public class Db : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Mark> Marks { get; set; }
    
    public Db(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }
}