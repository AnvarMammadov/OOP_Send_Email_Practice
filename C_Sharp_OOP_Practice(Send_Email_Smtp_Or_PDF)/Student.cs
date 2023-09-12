using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace C_Sharp_OOP_Practice_Send_Email_Smtp_Or_PDF_
{
    public class Student : Human
    {
        public Exam[]? Exams { get; set; } = new Exam[0];
        public string? Email { get; set; }
        public Student(string? name, string? surname, int age, string? email, Exam[]? exams)
            : base(name, surname, age) { Exams = exams; Email = email; }

        private double avgScore;
        public double GetAvgScore()
        {
            if (Validation.FlagNull(Exams))
            {
                foreach (var exam in Exams)
                {
                    avgScore += exam.Score;
                }
                avgScore /= Exams.Length;
                return avgScore;
            }
            return 0;

        }

        public Exam GetExam()
        {
            Console.Write("Enter Lesson Name : ");
            string? lessonName = Console.ReadLine();
            Console.Write("Enter Score : ");
            double examScore = Convert.ToDouble(Console.ReadLine());
            return new Exam(lessonName, examScore);
        }

        public void AddExam(Exam newExam)
        {
            if (Exams == null) Exams = new Exam[0];
            var temp = new Exam[Exams.Length + 1];
            Exams.CopyTo(temp, 0);
            temp[temp.Length - 1] = newExam;
            Exams = temp;
        }

        public void ShowExams()
        {
            if (Validation.FlagNull(Exams))
            {
                if (Exams.Length > 0)
                {
                    foreach (var exam in Exams)
                    {
                        exam.ShowExamDetails(); Console.WriteLine("------------------------------\n\n");
                    }
                }
                else
                {
                    Console.WriteLine($"This Student (Name : {Name} - Surname : {Surname}) has not exams ...");
                }
            }
        }

        public new void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Email : {Email}");
            Console.WriteLine($"Average Score : {GetAvgScore()}");
        }
    }
}
