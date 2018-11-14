using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomGenerator;

namespace StudentInformationSystem
{
    class Student
    {
        static int S_id = 1;

        public Student()
        {
            id = S_id++;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public int midtermExam1 { get; set; }
        public int midtermExam2 { get; set; }
        public int final { get; set; }

        public int Avg
        {
            get
            {
                return (int)(midtermExam1 * 0.3 + midtermExam2 * 0.3 + final * 0.4);
            }
        }

        static GenerateRandom gnrtr = new GenerateRandom();
        static Random rnd = new Random();

        static public Student generateStudent()
        {
            Student s = new Student()
            {
                name = gnrtr.generateSentence(rnd.Next(1, 2)),
                surname = gnrtr.generateWord(rnd.Next(3, 10)),
                age = rnd.Next(18, 25),
                midtermExam1 = rnd.Next(0, 100),
                midtermExam2 = rnd.Next(0, 100),
                final = rnd.Next(0, 100)
            };

            return s;
        }

        static public List<Student> generateStudentList()
        {
            List<Student> studentList = new List<Student>();

            for (int i = 0; i < rnd.Next(10, 20); i++)
            {
                studentList.Add(generateStudent());
            }

            return studentList;
        }

        public string getInfo()
        {
            return "id\t:" + id + "\nname\t:" + name + "\nsurname\t:" + surname + "\nexam1\t:" + midtermExam1 + "\nexam2\t:" + midtermExam2 + "\nfinal\t:" + final + "\navarage\t:" + Avg;
        }
    }
}
