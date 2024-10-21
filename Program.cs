using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirstStudentDatabase
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SchoolContext())
            {
                //Add a new student
                Console.WriteLine("Enter Student's fullname:");
                var name = Console.ReadLine();

                var stud = new Student { StudentName = name };
                db.Students.Add(stud);
                db.SaveChanges();

                Console.WriteLine("Student saved successfully!");

                //Display all students from the database
                var query = from s in db.Students orderby s.StudentName select s;

                Console.WriteLine("All Students in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.StudentName);
                }
                Console.WriteLine("Press ESC to exit...");
                Console.ReadKey();
            }
        }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public Grade Grade { get; set; }

    }
    public class Grade
    {
        public int GradeID { get; set; }
        public string Section { get; set; }

        public ICollection<Student> Students { get; set; }
    }

    public class SchoolContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }

}
