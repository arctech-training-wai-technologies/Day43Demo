using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day43Demo
{
    //private constructor
    public class Student
    {
        public  int age = 10;
        public string name = "James";

        public static Student student;
        private Student()
        {
            Console.WriteLine("Constructor called");
        }

        public static Student getObject()
        {
            if (student == null)
            {
                student = new Student();
            }
            return student;
        }
    }
    public class DemoPrivateConstructor
    {
        public void Demo()
        {
            Student student = Student.getObject();
            student.name = "abc";
            student.age = 40;

            Student student1 = Student.getObject();
            Console.WriteLine(student1.name);
            Console.WriteLine(student1.age);
        }
    }
}
