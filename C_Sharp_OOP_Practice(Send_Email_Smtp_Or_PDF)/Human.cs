using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_OOP_Practice_Send_Email_Smtp_Or_PDF_
{
    public abstract class Human
    {
        protected Human(string? name, string? surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public string? Name { get; set; } = "No Name";
        public string? Surname { get; set; } = "No Surname";
        public int Age { get; set; } = default;

        public void ShowInfo()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Surname : {Surname}");
            Console.WriteLine($"Age : {Age}\n");
        }
    }
}
