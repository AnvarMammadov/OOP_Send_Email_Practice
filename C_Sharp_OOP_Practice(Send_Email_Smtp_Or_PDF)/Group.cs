using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_OOP_Practice_Send_Email_Smtp_Or_PDF_
{
    public class Group
    {
        public Group(string?groupName,Teacher teacher, Student[]? students)
        {
            GroupName = groupName;
            Teacher = teacher;
            Students = students;
        }

        public Teacher Teacher{ get; set; }
        public Student[]? Students { get; set; }=new Student[0];
        public string? GroupName { get; set; } = "No Group Name";


        public void ShowGroupMembers()
        {
            Console.WriteLine($"\t\t\tGroup - {GroupName}\n\n");
            Console.WriteLine("\t\t = = = = T E A C H E R = = = =\n\n");
            if (Validation.FlagNull(Teacher))
            {
                Console.WriteLine($"Teacher : {Teacher.Name} {Teacher.Surname}");
            }
            Console.WriteLine("\n\n\t\t = = = = S T U D E N T S = = = =\n\n");
            if (Validation.FlagNull(Students))
            {
                int id = 0;
                foreach(var student in Students)
                {
                    Console.WriteLine($"{++id} . {student.Name} {student.Surname}\n");
                }
            }
        }



        public void ShowGroupTeacherDetails()
        {
            if (Validation.FlagNull(Teacher))
            {
                Console.WriteLine($"\t\t = = = = Teacher Information = = = =\n\n");
                Teacher.ShowInfo();
            }
        }



        public void ShowGroupStudentsDetails()
        {
            if (!Validation.FlagNull(Students))
            {
                int id = 0;
                foreach (var student in Students)
                {
                    Console.Write($"{++id}"); student.ShowInfo(); Console.WriteLine("----------------------------\n");
                }
            }
        }



    }
}
