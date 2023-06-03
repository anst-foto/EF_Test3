
using EF_Test3.DbLib;
using EF_Test3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var configBuilder = new ConfigurationBuilder();
configBuilder.SetBasePath(Directory.GetCurrentDirectory());
configBuilder.AddJsonFile("appsettings.json");
var config = configBuilder.Build();
var connectionString = config.GetConnectionString("DefaultConnection");

var optionsBuilder = new DbContextOptionsBuilder<Db>();
var options = optionsBuilder.UseLazyLoadingProxies().UseMySQL(connectionString).Options;
var db = new Db(options);

var marks = db.Marks.ToList();
var students = db.Students.ToList();
var subjects = db.Subjects.ToList();

/*var marks = db.Marks.ToList();
foreach (var mark in marks)
{
    Console.WriteLine($"{mark.Student.Person.LastName} {mark.Student.Person.FirstName} : {mark.Subject.Title} -> {mark.Grade}, {mark.Date:d}");
}*/

var marks2 = marks.Where(m => m.Grade == 3).ToList();
foreach (var mark in marks2)
{
    Console.WriteLine($"{mark.Student} : {mark.Date:d}");
}

db.Students.Add(new Student()
{
    Person = new Person()
    {
        FirstName = "Anonim",
        LastName = "Anonimus",
        Phone = "+71231234567"
    },
    Faculty = "Prog"
});
db.SaveChanges();

db.Subjects.Add(new Subject()
{
    Title = "Design"
});
db.SaveChanges();

var student = db.Students.First(s => s.Person.LastName == "Anonimus");
var subject = db.Subjects.First(s => s.Title == "Design");

db.Marks.Add(new Mark()
{
    Student = student,
    Subject = subject,
    Grade = 5,
    Date = new DateTime(2023, 05, 05)
});
db.SaveChanges();

marks = db.Marks.ToList();
foreach (var m in marks)
{
    Console.WriteLine($"{m.Student} : {m.Subject.Title} -> {m.Grade} : {m.Date:d}");
}