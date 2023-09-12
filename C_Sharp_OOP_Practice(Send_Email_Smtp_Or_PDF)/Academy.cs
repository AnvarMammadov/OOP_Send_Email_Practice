using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_OOP_Practice_Send_Email_Smtp_Or_PDF_
{
    public class Academy
    {
        public Academy(string? academyName)
        {
            AcademyName = academyName;
        }

        public string? AcademyName { get; set; } = "No Name";
        public Group[]? Groups { get; set; }=new Group[0];

        public string? AcademyEmail { get; } = "YOUR_EMAIL";
        public string? AcademyEmailPass { get; set; } = "YOUR_PASSWORD";

        public void ShowAllGroups()
        {
            if (Validation.FlagNull(Groups))
            {
                int id = 0;
                foreach (Group group in Groups) {
                    Console.WriteLine($"{++id} . {group.GroupName}\n");
                }
            }
        }
        
        public void ShowAcademyMembers() { 
            if (Validation.FlagNull(Groups))
            {
                int id = 0;
                foreach (Group group in Groups)
                {
                    Console.Write($"{++id} . ");group.ShowGroupMembers(); Console.WriteLine("---------------------\n");
                }
            }
        }



    }
}
