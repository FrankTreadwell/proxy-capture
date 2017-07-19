using CaptureFramework.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureFramework.Datastores
{
    public class Student
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }

    public interface IStudentDatastore
    {
        [Retrieval]
        Student GetStudentByID(int Id);

        [Alteration]
        void SaveStudent(Student student);
    }

    public class StudentDatastore : IStudentDatastore
    {
        public Student GetStudentByID(int Id)
        {
            Console.WriteLine($"Retreived student {Id} from the database.");
            return new Student()
            {
                EmailAddress = "test@aol.com",
                FirstName = "joe",
                LastName = "smith",
                id = Id
            };
        }

        public void SaveStudent(Student student)
        {
            Console.WriteLine($"Saving Student {student.id} to the database.");
        }
    }
}
