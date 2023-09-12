using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace C_Sharp_OOP_Practice_Send_Email_Smtp_Or_PDF_
{
    public class Program
    {
        static void Main(string[] args)
        {

            Academy academy=new Academy("Best Computer Academy");



            Student s1 = new Student("Anvar","Mammadov",22,"TEST@gmail.com",new Exam[0]);
            
            Student s2 = new Student("Murad","Gojayev",21, "TEST@gmail.com", new Exam[1] {new Exam("C++ Development",78.4)});

            Student s3 = new Student("Ali","Aliyev",23, "TEST@gmail.com", new Exam[2] {new Exam("C++ Development",91.6),
                new Exam("Python Development",92.5) });
  
            Student s4 = new Student("Coshqun","Hashimli",23, "TEST@gmail.com", new Exam[2] {new Exam("NetWork Programming",89.5),
            new Exam("Linux",98)});

            Teacher t1 = new Teacher("Elvin","Camalzade",25,10000);


            Group g1 = new Group("A-12", t1, new Student[] { s1, s2, s3, s4 });

            Student s5 = new Student("Leyla", "Mammadova", 34, "testleyla@gmail.com", new Exam[2] {new Exam("Designe",90.7),new Exam("Python Development",72.1)});

            Student s6 = new Student("Steve", "Aliyev", 21, "teststeve@gmail.com", new Exam[2] { new Exam("Designe", 56.2),new Exam("SQL",70.3) });

            Student s7 = new Student("Reshad", "Ahmedov", 23, "testreshad@gmail.com", new Exam[2] {new Exam("SQL",70),
                new Exam("Python Development",92.5) });

            Teacher t2 = new Teacher("Rafiq", "Nicatzade", 30, 7000);
            Group g2 = new Group("B-12", t2, new Student[] { s5, s6, s7});
                                                    
            academy.Groups = new Group[] { g1,g2};




            while (true)
            {
                MyClear();
                Console.WriteLine($"\t\t\t = = = W E L C O M E  {academy.AcademyName} = = =\n\n");
                int id = 0;
                foreach (var group in academy.Groups)
                {
                    Console.WriteLine($"{++id} ] {group.GroupName}");
                }
                string? choice=Console.ReadLine()?.Trim(); MyClear();

                if (choice != null)
                {
                    if (Convert.ToInt32(choice) > 0 && Convert.ToInt32(choice) < academy.Groups.Length + 1)
                    {
                        var currentGroup = academy.Groups[Convert.ToInt32(choice) - 1];
                        currentGroup.ShowGroupMembers();
                        Console.Write("\nChoose Student : "); string? chooseStudent = Console.ReadLine()?.Trim(); MyClear();
                        if (chooseStudent != null)
                        {
                            if (Convert.ToInt32(chooseStudent) > 0 && Convert.ToInt32(chooseStudent) < currentGroup.Students?.Length + 1)
                            {
                                var currentStudent = currentGroup.Students?[Convert.ToInt32(chooseStudent) - 1];
                                currentStudent?.ShowInfo(); Console.WriteLine
                                    ("\n----------------------------------\n\n\t\t= = = Exams = = =\n");
                                currentStudent?.ShowExams();
                                Console.Write("\nWould you like add exam ? [y/n] : ");
                                char yesOrNo = Convert.ToChar(Console.ReadLine().Trim().ToLower());
                                if (yesOrNo == 'n')
                                {
                                    continue;
                                }
                                else if (yesOrNo == 'y')
                                {
                                    var newExam = currentStudent?.GetExam();
                                    if (newExam != null)
                                    {
                                        currentStudent?.AddExam(newExam);
                                        Console.WriteLine("Exam Added Successfully...");
                                        Console.Write("Enter PDF name (.pdf) : ");
                                        string? pdfName= Console.ReadLine()?.Trim();
                                        string? text = 
                                            $"\t\t\tSender : {academy.AcademyName}\n" +
                                            $"Teacher : {currentGroup.Teacher.Name} {currentGroup.Teacher.Surname}\nSubject :" +
                                            $" {newExam.LessonName}\nScore : {newExam.Score}\nExam Date :" +
                                            $" {newExam.ExamDate.ToString("dd MMMM yyyy HH:mm")}";
                                        SendMail.SendMailExams
                                            (academy.AcademyEmail, academy.AcademyEmailPass, currentStudent?.Email, 
                                            newExam.LessonName, pdfName,text);
                                    }
                                }
                                else { Console.WriteLine("This operation not found..."); continue; }
                            }
                            else { Console.WriteLine("This student not found...");continue; }
                        }
                        else { Console.WriteLine("This operation not found..."); continue; }

                    }
                    else { Console.WriteLine("This group not found...");continue; }
                }
                else
                {
                    Console.WriteLine("This operation not found...");continue; 
                }
                Console.WriteLine("Press any key for continue .."); Console.ReadLine();
            }

        }
        public static void MyClear()
        {
            Console.Clear(); Console.WriteLine("\x1b[3J");
        }
    }
}