using System;
using System.Collections.Generic;

namespace MethodInjectionAndPropertyInjection
{
    class Program
    {
        static void Main(string[] args)
        {


            StudentBusinessLayer studentBusinessLayer = new StudentBusinessLayer();
            var data = studentBusinessLayer.GetStudents(new StudentDataAccessLayer());
            //below lines are just for property type injection
            //studentBusinessLayer.studentDataAccessLayer = new StudentDataAccessLayer();
            // var data = studentBusinessLayer.studentDataAccessLayer.GetStudents();

            foreach (var item in data)
            {
                Console.WriteLine(item.Name + " " + item.studentId);
            }


            Console.ReadLine();
        }
    }

    public class Student
    {
        public int studentId { get; set; }
        public string Name { get; set; }
    }
    public interface IStudentDataAccessLayer
    {
        List<Student> GetStudents();
    }
    public class StudentDataAccessLayer : IStudentDataAccessLayer
    {
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student { studentId = 1, Name = "Umar" });
            students.Add(new Student { studentId = 1, Name = "faraz" });
            students.Add(new Student { studentId = 1, Name = "Ahmed" });
            students.Add(new Student { studentId = 1, Name = "USman" });
            return students;
        }
    }
    public class StudentBusinessLayer
    {
        //  private  IStudentDataAccessLayer _studentDataAccessLayer;
        //public IStudentDataAccessLayer studentDataAccessLayer
        //  {
        //      set
        //      {
        //          _studentDataAccessLayer = value;
        //      }
        //      get
        //      {
        //          if (_studentDataAccessLayer == null)
        //          {
        //              throw new Exception("Object is not passed to the properly");
        //          }
        //          else
        //          {
        //              return _studentDataAccessLayer;
        //          }
        //      }
        //  }

        //  public List<Student> GetStudents()
        //  {
        //      return _studentDataAccessLayer.GetStudents();
        //  }

        public List<Student> GetStudents(IStudentDataAccessLayer studentDataAccessLayer)
        {
            return studentDataAccessLayer.GetStudents();
        }
    }
}
