using System;
using System.Collections;

namespace Compare
{
    class Program
    {
        static void Main()
        {
            //Group group1 = new Group();
            //group1.ShowStudents();
            //Console.WriteLine();

            //Group group2 = new Group(group1);
            //group2.EditGroup("Group 2", "Mathematics", 2);
            //group2.EditStudent(1, "FakeName1", "FakeName2", 20, 10);
            //group2.EditStudent(2, "FakeName1", "FakeName2", 20, 10);
            //group2.ShowStudents();

            //if (group1.checkEqualStudents(1, 2)) Console.WriteLine("\nStuds Equal\n");
            //else Console.WriteLine("\nStuds Not Equal\n");
            //if (group1 == group2) Console.WriteLine("\nGroups Equal\n");
            //else Console.WriteLine("\nGroups Not Equal\n");

            //Console.WriteLine();

            //group2.TransferStudent(0, group1);
            //group1.ShowStudents();
            //group2.ShowStudents();
            //Console.WriteLine();

            //group2.ExpelFailedStudents();
            //group2.ShowStudents();
            //Console.WriteLine();

            //group2.ExpelWorstStudent();
            //group2.ShowStudents();
            //Console.WriteLine();


            //Console.WriteLine(group1[2]);



            //Student [] students = new Student[5];

            //for (int i=0; i<5; i++) students[i] = new Student();
            //Array.Sort(students, new NameComparer());
            //for (int i = 0; i < 5; i++) students[i].ShowStud();



            Group gr1 = new Group();

            foreach (Student st in gr1)
            {
                st.ShowStud();
            }

            Console.WriteLine();

        }
    }
}
