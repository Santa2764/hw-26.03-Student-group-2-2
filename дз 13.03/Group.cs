using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Threading;

namespace Compare
{
    public class Person : IComparable    // класс Person
    {
        protected string firstName;
        protected string lastName;
        protected int age;
        protected int height;
        protected int weight;

        public Person()
        {
            lastName = GenerateName();
            firstName = GenerateName();
            age = GenerateAge();
        }

        protected static readonly Random rand = new Random();
        private static string GenerateName()
        {
            string[] names = { "Alex", "Bob", "Charlie", "David", "Emily", "Frank", "Grace", "Hannah", "Ivy", "Jack" };
            return names[rand.Next(names.Length)];
        }
        private static int GenerateAge()
        {
            return rand.Next(17, 25);
        }

        public string FirstName
        {
            set
            {
                bool isOk = false;
                while (!isOk)
                {
                    try
                    {
                        if (value.Length == 0)
                            throw new Exception();
                        else isOk = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong first name!");
                        value = Console.ReadLine();
                    }
                    firstName = value;
                }
            }
            get { return firstName; }
        }

        public string LastName
        {
            set
            {
                bool isOk = false;
                while (!isOk)
                {
                    try
                    {
                        if (value.Length == 0)
                            throw new Exception();
                        else isOk = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong last name!");
                        value = Console.ReadLine();
                    }
                    lastName = value;
                }
            }
            get { return lastName; }
        }

        public int Age
        {
            set
            {
                bool isOk = false;
                while (!isOk)
                {
                    try
                    {
                        if (value <= 17 || value > 25)
                            throw new Exception();
                        else isOk = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong age!");
                        value = Int32.Parse(Console.ReadLine());
                    }
                    age = value;
                }
            }
            get { return age; }
        }

        public int Height
        {
            set
            {
                bool isOk = false;
                while (!isOk)
                {
                    try
                    {
                        if (value <= 50 || value > 250)
                            throw new Exception();
                        else isOk = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong height!");
                        value = Int32.Parse(Console.ReadLine());
                    }
                    height = value;
                }
            }
            get { return height; }
        }

        public int Weight
        {
            set
            {
                bool isOk = false;
                while (!isOk)
                {
                    try
                    {
                        if (value <= 10 || value > 300)
                            throw new Exception();
                        else isOk = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong weight!");
                        value = Int32.Parse(Console.ReadLine());
                    }
                    weight = value;
                }
            }
            get { return weight; }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public static bool operator ==(Person p1, Person p2)
        {
            if (p1.age == p2.age) return true;
            else return false;
        }
        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }

        public int CompareTo(object obj) // реализация интерфейса
        {

            Person temp = obj as Person;
            if (this.age > temp.age) return 1;
            if (this.age < temp.age) return -1;
            return 0;
        }
    }

    public class Student : Person    // класс Student, дочерний класса Person
    {
        protected double gpa;

        public double GPA
        {
            set
            {
                bool isOk = false;
                while (!isOk)
                {
                    try
                    {
                        if (value <= 0 || value > 12)
                            throw new Exception();
                        else isOk = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong GPA!");
                        value = double.Parse(Console.ReadLine());
                    }
                    this.gpa = value;
                }
            }
            get { return gpa; }
        }

        public Student()
        {
            gpa = GenerateGPA();
        }

        public void ShowStud()
        {
            Console.WriteLine($"{this.firstName}, {this.gpa}");
        }

        private static double GenerateGPA()
        {
            return Math.Round(rand.NextDouble() * 2 + 3, 2);
        }

        public static bool operator ==(Student st1, Student st2)
        {
            if (st1.gpa == st2.gpa) return true;
            else return false;
        }
        public static bool operator !=(Student st1, Student st2)
        {
            return !(st1 == st2);
        }
        public int CompareTo(object obj) // реализация интерфейса
        {

            Student temp = obj as Student;
            if (this.gpa > temp.gpa) return 1;
            if (this.gpa < temp.gpa) return -1;
            return 0;
        }
    }

    public class Aspirant : Student    // класс Aspirant, дочерний класса Student
    {
        string theme;

        public double GPA
        {
            set
            {
                bool isOk = false;
                while (!isOk)
                {
                    try
                    {
                        if (value <= 0 || value > 12)
                            throw new Exception();
                        else isOk = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong GPA!");
                        value = double.Parse(Console.ReadLine());
                    }
                    this.gpa = value;
                }
            }
            get { return gpa; }
        }

        public Aspirant()
        {
            theme = "Random diss theme";
        }

        public static bool operator ==(Aspirant a1, Aspirant a2)
        {
            if (a1.age == a2.age) return true;
            else return false;
        }
        public static bool operator !=(Aspirant a1, Aspirant a2)
        {
            return !(a1 == a2);
        }
    }

    public class Group : IEnumerable  // класс Group
    {
        List<Student> students = new List<Student>();
        List<Aspirant> aspirants = new List<Aspirant>();
        string name;
        string specialization;
        int course;

        public Group()
        {
            name = "Group П11";
            specialization = "Computer Science";
            course = 1;
            for (int i = 0; i < 10; i++)
            {
                AddStudent();
            }
        }

        public Group(List<Student> students)
        {
            name = "Group П11";
            specialization = "Computer Science";
            course = 1;
            this.students = students;
        }

        public Group(Group group)
        {
            name = group.name;
            specialization = group.specialization;
            course = group.course;
            students = new List<Student>(group.students);
        }

        public void ShowStudents()
        {
            Console.WriteLine("Group name: " + name);
            Console.WriteLine("Specialization: " + specialization);
            Console.WriteLine("Course: " + course);
            Console.WriteLine("Students:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i].LastName} {students[i].FirstName} {students[i].Age}");
            }
        }

        public void AddStudent()
        {
            students.Add(new Student());
        }

        public void EditGroup(string name, string specialization, int course)
        {
            //this.name = name;
            bool isOk = false;
            while (!isOk)
            {
                try
                {
                    if (name.Length == 0)
                        throw new Exception();
                    else isOk = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong group name!");
                    name = Console.ReadLine();
                }
                this.name = name;
            }

            //this.specialization = specialization;
            isOk = false;
            while (!isOk)
            {
                try
                {
                    if (specialization.Length == 0)
                        throw new Exception();
                    else isOk = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong group specialization!");
                    specialization = Console.ReadLine();
                }
                this.specialization = specialization;
            }

            //this.course = course;
            isOk = false;
            while (!isOk)
            {
                try
                {
                    if (course <= 0 || course > 5)
                        throw new Exception();
                    else isOk = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong group course!");
                    course = Int32.Parse(Console.ReadLine());
                }
                this.course = course;
            }
        }

        public void EditStudent(int index, string lastName, string firstName, int age, double gpa)
        {
            bool isOk = false;
            while (!isOk)
            {
                try
                {
                    if (index < 0 || index > students.Count)
                        throw new Exception();
                    else isOk = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong index!");
                    index = Int32.Parse(Console.ReadLine());
                }
            }

            students[index].LastName = lastName;
            students[index].FirstName = firstName;
            students[index].Age = age;
            students[index].GPA = gpa;
        }

        public void TransferStudent(int index, Group group)
        {
            group.students.Add(students[index]);
            students.RemoveAt(index);
        }

        public void ExpelFailedStudents()
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].GPA < 3.0)
                {
                    students.RemoveAt(i);
                    i--;
                }
            }
        }

        public void ExpelWorstStudent()
        {
            int worstIndex = 0;
            double worstGPA = students[0].GPA;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].GPA < worstGPA)
                {
                    worstIndex = i;
                    worstGPA = students[i].GPA;
                }
            }
            students.RemoveAt(worstIndex);
        }

        public bool checkEqualStudents(int st1, int st2)
        {
            if (students[st1] == students[st2]) return true;
            else return false;
        }

        public static bool operator ==(Group g1, Group g2)
        {
            if (g1.students.Count == g2.students.Count) return true;
            else return false;
        }
        public static bool operator !=(Group g1, Group g2)
        {
            return !(g1 == g2);
        }

        public Student this[int i]
        {
            get
            {
                if (i < 0 || i >= students.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {students[i].LastName} {students[i].FirstName}");
                    return students[i] as Student;
                }
            }
            set { students[i] = value as Student; }
        }

        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(students);
        }
    }

    public class NameComparer : IComparer<Student>
    {
        public int Compare(Student left, Student right)
        {
            for (int i = 0; i < left.FirstName.Length; i++)
            {
                if (left.FirstName[i] > right.FirstName[i]) return 1;
                else if (left.FirstName[i] < right.FirstName[i]) return -1;
            }
            return 0;
        }
    }
    public class AgeComparer : IComparer<Student>
    {
        public int Compare(Student left, Student right)
        {
            if (left.Age < right.Age) return 1;
            else if (left.Age > right.Age) return -1;
            else return 0;
        }
    }
    class StudentEnumerator : IEnumerator
    {
        public object Current
        {
            get;
            private set;
        }

        private int step;
        List<Student> students = new List<Student>();

        public StudentEnumerator(List<Student> arr)
        {
            this.students = arr;
        }

        public bool MoveNext()
        {
            if (step >= students.Count) return false;
            Current = students[step++];
            return true;
        }

        public void Reset()
        {
            // TO DO: https://learn.microsoft.com/ru-ru/dotnet/api/system.collections.ienumerator.reset?view=net-7.0
        }
    }
}
