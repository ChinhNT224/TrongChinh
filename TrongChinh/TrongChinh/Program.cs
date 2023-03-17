using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrongChinh
{
    interface IStudent
    {
        int StudID { get; set; }
        string StudName { get; set; }
        string StudGender { get; set; }
        int StudAge { get; set; }
        string StudClass { get; set; }
        float StudAvgMark { get; }
        void Print();
    }

    class Student : IStudent
    {
        public int StudID { get; set; }
        public string StudName { get; set; }
        public string StudGender { get; set; }
        public int StudAge { get; set; }
        public string StudClass { get; set; }
        public float StudAvgMark { get; private set; }
        private int[] MarkList = new int[3];

        public int this[int index]
        {
            get { return MarkList[index]; }
            set { MarkList[index] = value; }
        }

        public void Print()
        {
            Console.WriteLine("ID: {0}, Name: {1}, Gender: {2}, Age: {3}, Class: {4}", StudID, StudName, StudGender, StudAge, StudClass);
        }

        public void CalAvg()
        {
            int total = 0;
            for (int i = 0; i < 3; i++)
            {
                total += MarkList[i];
            }
            StudAvgMark = total / 3.0f;
            Console.WriteLine("Avenger mark: {0}", StudAvgMark);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Hashtable students = new Hashtable();

            while (true)
            {
                Console.WriteLine("========== Student Management System ==========");
                Console.WriteLine("1. Insert new student...");
                Console.WriteLine("2. Display all the student list...");
                Console.WriteLine("3. Calculator average mark...");
                Console.WriteLine("4. Find ...");
                Console.WriteLine("5. Exit...");
                Console.WriteLine("===============================================");
                Console.Write("Option: ");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Student newStudent = new Student();

                        Console.WriteLine("Insert new student...");

                        Console.Write("Input student ID: ");
                        newStudent.StudID = int.Parse(Console.ReadLine());

                        Console.Write("Input student name: ");
                        newStudent.StudName = Console.ReadLine();

                        Console.Write("Input student gender: ");
                        newStudent.StudGender = Console.ReadLine();

                        Console.Write("Input student age: ");
                        newStudent.StudAge = int.Parse(Console.ReadLine());

                        Console.Write("Input student class: ");
                        newStudent.StudClass = Console.ReadLine();

                        for (int i = 0; i < 3; i++)
                        {
                            Console.Write("Input mark {0}: ", i + 1);
                            newStudent[i] = int.Parse(Console.ReadLine());
                        }
                        students.Add(newStudent.StudID, newStudent);
                        break;

                    case 2:
                        Console.WriteLine("========== List of Students ==========");
                        foreach (Student s in students.Values)
                        {
                            s.Print();
                        }
                        break;

                    case 3:
                        Console.WriteLine("========== Average Mark for All Students ==========");
                        foreach (Student s in students.Values)
                        {
                            s.Print();
                            s.CalAvg();
                        }
                        break;

                    case 4:
                        Console.WriteLine("=======================Find====================");
                        Console.WriteLine("6. Find by ID...");
                        Console.WriteLine("7. Find by Name...");
                        Console.WriteLine("8. Find by Class...");
                        Console.WriteLine("9. Quit...");
                        Console.WriteLine("===============================================");
                        Console.Write("Choice: ");

                        int choice = int.Parse(Console.ReadLine());

                        if (choice == 6)
                        {
                            int ID = Convert.ToInt32(Console.ReadLine());
                            foreach (Student s in students.Values)
                            {
                                if (s.StudID == ID)
                                {
                                    s.Print();
                                }
                            }
                        }
                        if(choice == 7)
                        {
                            string name = Convert.ToString(Console.ReadLine());
                            foreach (Student s in students.Values)
                            {
                                if (s.StudName == name)
                                {
                                    s.Print();
                                }
                            }
                        }
                        if (choice == 8)
                        {
                            string Class = Convert.ToString(Console.ReadLine());
                            foreach (Student s in students.Values)
                            {
                                if (s.StudClass == Class)
                                {
                                    s.Print();
                                }
                            }
                        }
                        if(choice == 9)
                        {
                            break;
                        }
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please enter again.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}

