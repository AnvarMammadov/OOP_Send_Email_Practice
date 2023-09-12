using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_OOP_Practice_Send_Email_Smtp_Or_PDF_
{
    public class Teacher : Human
    {
        public double Salary { get; set; }
        public Teacher(string? name, string? surname, int age, double salary) : base(name, surname, age) { Salary = salary; }

        public new void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Salary : {Salary}");
        }

    }
}