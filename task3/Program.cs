

    using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentSystemApp 
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

        public override string ToString()
        {
            return $"{Id} - {Name}, Age: {Age}, Courses: {Courses.Count}";
        }
    }

    class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name}, Dept: {Dept}";
        }
    }

    class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }

        public override string ToString()
        {
            string inst = Instructor != null ? Instructor.Name : "None";
            return $"{Id} - {Title}, Instructor: {inst}";
        }
    }

    class StudentManager
    {
        List<Student> students = new List<Student>();
        List<Course> courses = new List<Course>();
        List<Instructor> instructors = new List<Instructor>();

        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Student Management System ---");
                Console.WriteLine("1 Add Student");
                Console.WriteLine("2 View Students");
                Console.WriteLine("3 Search Student");
                Console.WriteLine("4 Update Student");
                Console.WriteLine("5 Delete Student");
                Console.WriteLine("6 Add Course");
                Console.WriteLine("7 Add Instructor");
                Console.WriteLine("8 Enroll Student");
                Console.WriteLine("9 View Courses");
                Console.WriteLine("10 View Instructors");
                Console.WriteLine("0 Exit");
                Console.Write("Choose: ");
                string input = Console.ReadLine();

                Console.Clear();

                switch (input)
                {
                    case "1" : AddStudent(); break;
                    case "2": ViewStudents(); break;
                    case "3": SearchStudent(); break;
                    case "4": UpdateStudent(); break;
                    case "5": DeleteStudent(); break;
                    case "6": AddCourse(); break;
                    case "7": AddInstructor(); break;
                    case "8": EnrollStudent(); break;
                    case "9": ViewCourses(); break;
                    case "10": ViewInstructors(); break;
                    case "0": exit = true; break;
                    default: Console.WriteLine("Invalid choice!"); break;
                }
            }
        }

        void AddStudent()
        {
            Student s = new Student();
            Console.Write("Enter ID: ");
            s.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            s.Name = Console.ReadLine();
            Console.Write("Enter Age: ");
            s.Age = int.Parse(Console.ReadLine());
            students.Add(s);
            Console.WriteLine("Student added.");
        }

        void ViewStudents()
        {
            if (students.Count == 0)
                Console.WriteLine("No students found.");
            else
                foreach (var s in students) Console.WriteLine(s);
        }

        void SearchStudent()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var s = students.FirstOrDefault(x => x.Id == id);
            if (s == null) Console.WriteLine("Student not found.");
            else Console.WriteLine(s);
        }

        void UpdateStudent()
        {
            Console.Write("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var s = students.FirstOrDefault(x => x.Id == id);
            if (s == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("New name: ");
            s.Name = Console.ReadLine();
            Console.Write("New age: ");
            s.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Updated.");
        }

        void DeleteStudent()
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            var s = students.FirstOrDefault(x => x.Id == id);
            if (s == null) Console.WriteLine("Not found.");
            else
            {
                students.Remove(s);
                Console.WriteLine("Deleted.");
            }
        }

        void AddCourse()
        {
            Course c = new Course();
            Console.Write("Enter ID: ");
            c.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Title: ");
            c.Title = Console.ReadLine();
            courses.Add(c);
            Console.WriteLine("Course added.");
        }

        void AddInstructor()
        {
            Instructor i = new Instructor();
            Console.Write("Enter ID: ");
            i.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            i.Name = Console.ReadLine();
            Console.Write("Enter Department: ");
            i.Dept = Console.ReadLine();
            instructors.Add(i);
            Console.WriteLine("Instructor added.");
        }

        void EnrollStudent()
        {
            Console.Write("Enter Student ID: ");
            int sid = int.Parse(Console.ReadLine());
            Console.Write("Enter Course ID: ");
            int cid = int.Parse(Console.ReadLine());

            var s = students.FirstOrDefault(x => x.Id == sid);
            var c = courses.FirstOrDefault(x => x.Id == cid);

            if (s == null || c == null)
            {
                Console.WriteLine("Invalid IDs.");
                return;
            }

            s.Courses.Add(c);
            Console.WriteLine("Enrolled successfully.");
        }

        void ViewCourses()
        {
            if (courses.Count == 0) Console.WriteLine("No courses found.");
            else foreach (var c in courses) Console.WriteLine(c);
        }

        void ViewInstructors()
        {
            if (instructors.Count == 0) Console.WriteLine("No instructors found.");
            else foreach (var i in instructors) Console.WriteLine(i);
        }
    }

    class Program
    {
        static void Main()
        {
            StudentManager sm = new StudentManager();
            sm.Run();
        }
    }
}