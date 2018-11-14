using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem
{
    class Program
    {
        static List<Student> students = Student.generateStudentList();

        static void Main(string[] args)
        {
            menu();
        }

        private static void menu()
        {
            Console.Clear();

            Console.WriteLine("1.\tStudent transactions");
            Console.WriteLine("2.\tFind student");
            Console.WriteLine("3.\tView students details");
            Console.WriteLine("4.\tView students statics");
            Console.WriteLine("5.\tExit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    transactions();
                    break;
                case "2":
                    findStudent();
                    break;
                case "3":
                    viewDetails();
                    break;
                case "4":
                    viewStatics();
                    break;
                case "5":
                    exit();
                    break;
                default:
                    invalidChoice();
                    break;
            }
        }

        private static void invalidChoice()
        {
            Console.Clear();
            Console.WriteLine("Wrong choice...");
            Console.ReadLine();
            transactions();
        }

        private static void findStudent()
        {
            Console.Clear();

            Console.Write("Enter the student id : ");
            string idS = Console.ReadLine();

            if (checkValue(idS))
            {
                var student = students.Where(p => p.id == int.Parse(idS)).FirstOrDefault();

                if (student != null)
                {
                    Console.WriteLine();
                    Console.WriteLine(student.getInfo());
                }

                else
                    Console.WriteLine($"There is no student where id = {idS}");
            }

            else
                Console.WriteLine("İnvalid input");

            Console.ReadLine();
            Console.Clear();
            menu();
        }

        private static bool checkValue(string s)
        {
            int result;

            if (int.TryParse(s, out result))
                return true;
            else
                return false;
        }

        private static void transactions()
        {
            Console.Clear();

            Console.WriteLine("1.\tAdd student");
            Console.WriteLine("2.\tDelete student");
            Console.WriteLine("3.\tModify student");
            Console.WriteLine("4.\tMain menu");
            Console.WriteLine("5.\tExit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    addStudent();
                    break;
                case "2":
                    deleteStudent();
                    break;
                case "3":
                    modifyStudent();
                    break;
                case "4":
                    menu();
                    break;
                case "5":
                    exit();
                    break;
                default:
                    invalidChoice();
                    break;
            }
        }

        private static void modifyStudent()
        {
            Console.Clear();

            Console.Write("Enter the student id : ");
            string idS = Console.ReadLine();

            if (checkValue(idS))
            {
                var student = students.Where(p => p.id == int.Parse(idS)).FirstOrDefault();

                if (student != null)
                {
                    Console.Write("name : ");
                    string nameN = Console.ReadLine();

                    if (!String.IsNullOrEmpty(nameN))
                    {
                        Console.Write("surname : ");
                        string surnameN = Console.ReadLine();

                        if (!String.IsNullOrEmpty(surnameN))
                        {
                            Console.Write("age : ");
                            string ageN = Console.ReadLine();

                            if (checkValue(ageN))
                            {
                                Console.Write("midterm Exam 1 : ");
                                string midtermExam1N = Console.ReadLine();

                                if (checkValue(midtermExam1N))
                                {
                                    Console.Write("midterm Exam 2 : ");
                                    string midtermExam2N = Console.ReadLine();

                                    if (checkValue(midtermExam2N))
                                    {
                                        Console.Write("final : ");
                                        string finalN = Console.ReadLine();

                                        if (checkValue(finalN))
                                        {
                                            student.name = nameN;
                                            student.surname = surnameN;
                                            student.age = int.Parse(ageN);
                                            student.midtermExam1 = int.Parse(midtermExam1N);
                                            student.midtermExam2 = int.Parse(midtermExam2N);
                                            student.final = int.Parse(finalN);

                                            Console.WriteLine("Transaction is successfull");
                                        }

                                        else
                                            Console.WriteLine("invalid input");
                                    }

                                    else
                                        Console.WriteLine("invalid input");
                                }

                                else
                                    Console.WriteLine("invalid input");
                            }

                            else
                                Console.WriteLine("invalid input");
                        }
                        else
                            Console.WriteLine("invalid input");
                    }

                    else
                        Console.WriteLine("invalid input");
                }

                else
                    Console.WriteLine($"There is any student where id = {idS}");
            }

            else
            {
                Console.WriteLine("İnvalid input");
            }

            Console.ReadLine();
            Console.Clear();
            menu();
        }

        private static void deleteStudent()
        {
            Console.Clear();

            Console.Write("Enter the student id : ");
            string idS = Console.ReadLine();

            if (checkValue(idS))
            {
                var student = students.Where(p => p.id == int.Parse(idS)).FirstOrDefault();

                if (student != null)
                {
                    students.Remove(student);

                    Console.WriteLine("Transaction is successfull");
                }

                else
                {
                    Console.WriteLine($"There are any student where id = {idS}");
                }
            }

            else
                Console.WriteLine("İnvalid input");

            Console.ReadLine();
            Console.Clear();
            menu();
        }

        private static void addStudent()
        {
            Console.Clear();

            Console.Write("name : ");
            string nameN = Console.ReadLine();

            if (!String.IsNullOrEmpty(nameN))
            {
                Console.Write("surname : ");
                string surnameN = Console.ReadLine();

                if (!String.IsNullOrEmpty(surnameN))
                {
                    Console.Write("age : ");
                    string ageN = Console.ReadLine();

                    if (checkValue(ageN))
                    {
                        Student s = new Student()
                        {
                            name = nameN,
                            surname = surnameN,
                            age = int.Parse(ageN),
                            midtermExam1 = 0,
                            midtermExam2 = 0,
                            final = 0
                        };

                        students.Add(s);

                        Console.WriteLine("Transaction is successfull");
                    }
                    else
                        Console.WriteLine("İnvalid input");
                }
                else
                    Console.WriteLine("invalid input");
            }

            else
                Console.WriteLine("invalid input");

            Console.ReadLine();
            Console.Clear();
            menu();
        }

        private static void exit()
        {
            Environment.Exit(0);
        }

        private static void viewStatics()
        {
            Console.Clear();

            var minExam1 = students.Where(p => p.midtermExam1 == students.Min(q => q.midtermExam1));
            var minExam2 = students.Where(p => p.midtermExam2 == students.Min(q => q.midtermExam2));
            var minFinal = students.Where(p => p.final == students.Min(q => q.final));
            var minAvg = students.Where(p => p.Avg == students.Min(q => q.Avg));

            var maxExam1 = students.Where(p => p.midtermExam1 == students.Max(q => q.midtermExam1));
            var maxExam2 = students.Where(p => p.midtermExam2 == students.Max(q => q.midtermExam2));
            var maxFinal = students.Where(p => p.final == students.Max(q => q.final));
            var maxAvg = students.Where(p => p.Avg == students.Max(q => q.Avg));

            Console.WriteLine("Min exam1 note :");
            foreach (var item in minExam1)
            {
                Console.WriteLine(item.name + " " + item.surname + " " + item.midtermExam1);
            }

            Console.WriteLine();

            Console.WriteLine("Min exam2 note :");
            foreach (var item in minExam2)
            {
                Console.WriteLine(item.name + " " + item.surname + " " + item.midtermExam2);
            }

            Console.WriteLine();

            Console.WriteLine("Min final note :");
            foreach (var item in minFinal)
            {
                Console.WriteLine(item.name + " " + item.surname + " " + item.final);
            }

            Console.WriteLine();

            Console.WriteLine("Min avarage note :");
            foreach (var item in minAvg)
            {
                Console.WriteLine(item.name + " " + item.surname + " " + item.Avg);
            }

            Console.WriteLine();

            Console.WriteLine("Max exam1 note :");
            foreach (var item in maxExam1)
            {
                Console.WriteLine(item.name + " " + item.surname + " " + item.midtermExam1);
            }

            Console.WriteLine();

            Console.WriteLine("Max exam2 note :");
            foreach (var item in maxExam2)
            {
                Console.WriteLine(item.name + " " + item.surname + " " + item.midtermExam2);
            }

            Console.WriteLine();

            Console.WriteLine("Max final note :");
            foreach (var item in maxFinal)
            {
                Console.WriteLine(item.name + " " + item.surname + " " + item.final);
            }

            Console.WriteLine();

            Console.WriteLine("Max avarage note :");
            foreach (var item in maxAvg)
            {
                Console.WriteLine(item.name + " " + item.surname + " " + item.Avg);
            }

            Console.ReadLine();
            Console.Clear();
            menu();
        }

        private static void viewDetails()
        {
            Console.Clear();

            foreach (var item in students)
            {
                Console.WriteLine(item.getInfo());
                Console.WriteLine();
            }

            Console.ReadLine();
            Console.Clear();
            menu();
        }
    }
}
