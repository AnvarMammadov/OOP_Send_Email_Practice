using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_OOP_Practice_Send_Email_Smtp_Or_PDF_
{
    public class Exam
    {
        public Exam(string? lessonName, double score)
        {
            LessonName = lessonName;
            Score = score;
            ExamDate = DateTime.Now;
        }

        public string? LessonName { get; set; } = "No Lesson";
        public double Score { get; set; }=default(double);
        public DateTime ExamDate { get; set; }=DateTime.Now;
        
        public void ShowExamDetails()
        {
            Console.WriteLine($"Lesson Name : {LessonName}");
            Console.WriteLine($"Score : {Score}");
            Console.WriteLine($"Exam Date : {ExamDate}");
        }
    }
}
