using System;
using System.Collections.Generic;

namespace Retake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Report report = new Report();
            Console.WriteLine("Geef de naam in van jouw leerkracht");
            string Name = Console.ReadLine();
            Console.WriteLine("Geef de naam in van jouw klas");
            string ClassName = Console.ReadLine();
            @class Class = new @class();
            Class.Name = Name;
            report.teacher = new teacher() { Name = Name, Class = Class };
            report.Class = Class;
            List<student> PassStudents = new List<student>();
            List<student> distinctionStudents = new List<student>();
            List<student> ClassAverage = new List<student>();
            List<student> reTakes = new List<student>();

            /*Hoeveel studenten zijn er in de klas?*/
            int StudentNumber;
            Console.WriteLine("Hoeveel studenten zitten in de klas?");
            try
            {
                bool result = int.TryParse(Console.ReadLine(), out StudentNumber);

                //Hoeveel vakken zijn er in de klas

                int subjectsNumber;
                Console.WriteLine("Hoeveel vakken (examens) zijn er in de klas?");
                bool subjectsresult = int.TryParse(Console.ReadLine(), out subjectsNumber);

                /*
                 * Hallo Ammar! Enjoy this application :-)
                   Class 1GRA-ODISEE
                */

                Console.WriteLine(
                    $"\n\nHallo {report.teacher.Name}! Geniet van deze applicatie :-)" +
                    $"\n\n\nClass {ClassName}" +
                    $"\n\n-------\n\n"
                    );

                Console.Write($"Nr\tName\t\t");
                for (int i = 0; i < subjectsNumber; i++)
                {
                    Console.Write($"Vak {i + 1}\t\t");
                }
                Console.WriteLine("\n");
                for (int i = 0; i < StudentNumber; i++)
                {
                    Console.WriteLine($"{i + 1}\t\n");
                }

                /*Geef de naam in van de studenten*/
                List<student> students = new List<student>();
                Console.WriteLine("Geef de naam in van de studenten\n");
                for (int i = 0; i < StudentNumber; i++)
                {
                    Console.WriteLine($"\nGeef de naam in van de student {i + 1}");
                    student student = new student() { Class = Class, Name = Console.ReadLine() };
                    students.Add(student);
                }
                report.student = students;

                int min = 0;

                string name = string.Empty;

                for (int i = 0; i < report.student.Count - 1; i++)
                {
                    for (int j = i + 1; j < report.student.Count; j++)
                    {

                        if (report.student[i].Name.Length < report.student[j].Name.Length)
                            min = report.student[i].Name.Length;
                        else
                            min = report.student[j].Name.Length;
                        for (int k = 0; k < min; k++)
                        {
                            if (report.student[i].Name[k] > report.student[j].Name[k])
                            {
                                name = report.student[i].Name.ToString();
                                report.student[i].Name = report.student[j].Name;
                                report.student[j].Name = name;
                                break;
                            }
                            else if (report.student[i].Name[k] == report.student[j].Name[k])
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }

                        }
                    }
                }

                /*Geef de naam in van de vakken*/
                List<subject> courses = new List<subject>();
                Console.WriteLine("Geef de naam in van de vakken\n");
                for (int i = 0; i < subjectsNumber; i++)
                {
                    Console.WriteLine($"\nGeef de naam in van het vak {i + 1}");
                    subject subject = new subject() { Class = Class, Name = Console.ReadLine() };
                    courses.Add(subject);
                }

                report.subject = courses;
                int minL = 0;

                string namecouse = string.Empty;

                for (int i = 0; i < report.subject.Count - 1; i++)
                {
                    for (int j = i + 1; j < report.subject.Count; j++)
                    {

                        if (report.subject[i].Name.Length < report.subject[j].Name.Length)
                            minL = report.subject[i].Name.Length;
                        else
                            minL = report.subject[j].Name.Length;
                        for (int k = 0; k < min; k++)
                        {
                            if (report.subject[i].Name[k] > report.subject[j].Name[k])
                            {
                                namecouse = report.subject[i].Name.ToString();
                                report.subject[i].Name = report.subject[j].Name;
                                report.subject[j].Name = namecouse;
                                break;
                            }
                            else if (report.subject[i].Name[k] == report.subject[j].Name[k])
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }

                        }
                    }
                }

                foreach (var item in report.student)
                {
                    foreach (var subject in report.subject)
                    {

                        item.subject.Add(new subject() { Name = subject.Name, Degree = 0, Class = subject.Class });
                    }

                }

                Console.Clear();

                Console.WriteLine(
                    $"\n\nHallo {report.teacher.Name}! Geniet van deze applicatie :-)" +
                    $"\n\n\nClass {ClassName}" +
                    $"\n\n-------\n\n"
                    );

                Console.Write($"Nr\tName\t\t");
                foreach (subject item in report.subject)
                {
                    Console.Write($"{item.Name}\t\t");
                }

                Console.WriteLine("\n");
                for (int i = 0; i < StudentNumber; i++)
                {
                    Console.WriteLine($"{i + 1}\t{report.student[i].Name}\t\t\n");
                }

                /*Geef de naam in van klas -- voor het vak --.*/
                for (int i = 0; i < subjectsNumber; i++)
                {
                    Console.WriteLine($"\nGeef de punten in van de klas van {report.Class.Name} voor het vak " + $"{report.subject[i].Name}" + ".\n");
                    for (int j = 0; j < StudentNumber; j++)
                    {
                        int degree;
                        bool resultCheck = false;
                        do
                        {
                            Console.Write($"{report.student[j].Name} :  ");
                            resultCheck = int.TryParse(Console.ReadLine(), out degree);
                            if (degree < 0)
                            {
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                                Console.WriteLine("\t\t->  Dit is niet mogelijk (minimum is 0).. Probeer opnieuw!");
                            }
                            else if (degree > 20)
                            {
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);

                                Console.WriteLine("\t\t->  Dit is niet mogelijk (maximum is 20).. Probeer opnieuw!");
                            }

                        } while (!(0 <= degree && degree <= 20));
                        report.student[j].subject[i].Degree = degree;
                    }
                    Console.WriteLine("--------------------------------------------------------------------------------");
                }

                //Console.Clear();

                for (int i = 0; i < StudentNumber; i++)
                {
                    int Count = 0;
                    foreach (var item in report.student[i].subject)
                    {
                        Count += item.Degree;
                    }
                    report.student[i].TotalDegree = Count;
                }

                Console.WriteLine(
                    $"\n\nHallo {report.teacher.Name}! Geniet van deze applicatie :-)" +
                    $"\n\n\nClass {report.Class.Name}" +
                    $"\n\n-------\n\n"
                    );

                Console.Write($"Nr\tName\t\t");
                foreach (subject item in report.subject)
                {
                    Console.Write($"{item.Name}\t ");
                }

                Console.WriteLine("\n");
                //Console.ForegroundColor = ConsoleColor.Red;

                for (int i = 0; i < StudentNumber; i++)
                {

                    if (report.student[i].Name.Length >= 8)
                    {
                        Console.Write($"{i + 1}\t{report.student[i].Name}\t");

                    }
                    else
                    {
                        Console.Write($"{i + 1}\t{report.student[i].Name}\t\t");
                    }
                    Console.Write("\t");

                    foreach (var item in report.student[i].subject)
                    {
                        if (item.Degree > 12)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (item.Degree == 10 || item.Degree == 11)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        Console.Write($"{item.Degree}\t\t");
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n");
                }


                //Geslaagd of herexamens?
                Console.WriteLine("Geslaagd of herexamens?\n");
                foreach (var item in report.student)
                {

                    double StudentDegree = Math.Round((item.TotalDegree / (subjectsNumber * 20.0)) * 100);
                    if (StudentDegree > 50 && StudentDegree < 70) // >50 en <70: voldoende
                    {
                        Console.Write($"{item.Name}:\t");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Geslaagd");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" (Voldoende)\n");
                        PassStudents.Add(item);
                        Subjwarning(item.Name, item.subject);
                    }
                    else if (StudentDegree > 70 && StudentDegree < 75)// >70 en <75: distinction
                    {
                        Console.Write($"{item.Name}:\t");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Geslaagd");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" (Onderscheiding)\n");
                        PassStudents.Add(item);
                        distinctionStudents.Add(item);
                        Subjwarning(item.Name, item.subject);
                    }
                    else if (StudentDegree > 75 && StudentDegree < 80)//>75 en <80: grote onderscheiding
                    {
                        Console.Write($"{item.Name}:\t");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Geslaagd");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" (Grote onderscheiding)\n");
                        PassStudents.Add(item);
                        Subjwarning(item.Name, item.subject);
                    }
                    else if (StudentDegree > 80) // grootste onderscheiding
                    {
                        Console.Write($"{item.Name}:\t");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Geslaagd");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" (Grootste onderscheiding)\n");
                        PassStudents.Add(item);
                        Subjwarning(item.Name, item.subject);
                    }
                    else
                    {
                        Console.Write($"{item.Name}:\t");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Niet geslaagd\n");
                        ClassAverage.Add(item);
                        reTakes.Add(item);
                        Console.ForegroundColor = ConsoleColor.White;
                        Rexeame(item.Name, item.subject);
                    }

                }

                Console.WriteLine("\n-------------------------        RAPPORT    --------------------------\n");

                Console.WriteLine($"De gemiddelde score per vak:\n");
                foreach (var item in report.subject)
                {
                    SubjAverage(item.Name, report.student);
                }

                worstSubj(report.student);

                BestSubj(report.student);

                averageScore(report.subject, report.student);

                bestStudent(report.student);

                worstStudent(report.student);

                highestWebTech(report.student);

                highestSubjectStudent(report.student);

                passedStudent(PassStudents);

                PhilippeScor(report.student);//

                PhilippeAverageScor(report.student);

                distinctionStudent(distinctionStudents);//

                LowAverage(ClassAverage);

                reTake(reTakes);

                ProgrammingReTake(reTakes);

                MostReExams(reTakes);
            }
            catch (Exception)
            {
                Console.WriteLine("Voer de juiste gegevens in");
            }


            static void warning(string name)
            {
                Console.WriteLine($"\t{name} Heeft een waarschuwing voor:\n");
            }

            static void Subjwarning(string name, List<subject> subjects)
            {
                bool isUsed = false;
                foreach (var s in subjects)
                {
                    if (s.Degree < 10)
                    {
                        if (!isUsed)
                        {
                            warning(name);
                            isUsed = true;
                        }
                        Console.WriteLine($"\t-{s.Name}\n");
                    }
                }
            }

            static void Rexeame(string name, List<subject> subjects)
            {
                Console.WriteLine($"\t{name} Heeft een herexamen voor:\n");
                foreach (var s in subjects)
                {
                    if (s.Degree < 12)
                    {
                        s.count++;
                        Console.WriteLine($"\t-{s.Name}\n");
                    }
                }
            }

            static void SubjAverage(string subjName, List<student> students)
            {
                double sum = 0;
                foreach (var item in students)
                {
                    foreach (var s in item.subject)
                    {
                        if (s.Name == subjName)
                        {
                            sum += s.Degree;
                        }
                    }
                }
                Console.WriteLine($"De gemiddelde score voor {subjName}: {sum / students.Count}\n");
            }

            static void worstSubj(List<student> students)
            {
                Console.WriteLine($"Het slechtste vak van de klas:\n");
                subject subj = students[0].subject[0];
                foreach (var item in students)
                {
                    foreach (var s in item.subject)
                    {
                        if (subj.Degree > s.Degree)
                        {
                            subj = s;
                        }
                    }
                }
                Console.WriteLine(subj.Name);
            }

            static void BestSubj(List<student> students)
            {
                Console.WriteLine($"Het beste vak van de klas:\n");
                subject subj = students[0].subject[0];
                foreach (var item in students)
                {
                    foreach (var s in item.subject)
                    {
                        if (subj.Degree < s.Degree)
                        {
                            subj = s;
                        }
                    }
                }
                Console.WriteLine(subj.Name);
            }

            static void averageScore(List<subject> subjects, List<student> students)
            {
                Console.WriteLine($"De gemiddelde score van alle vakken van alle studenten:\n");
                subject subj = subjects[0];
                double sum = 0;
                foreach (var s in students)
                {
                    sum += (s.TotalDegree / subjects.Count);
                }
                Console.WriteLine($"Het gemiddelde : {sum / students.Count}\n");
            }

            static void bestStudent(List<student> students)
            {
                Console.WriteLine($"De beste student:\n");
                student stu = students[0];
                foreach (var s in students)
                {
                    if (stu.TotalDegree < s.TotalDegree)
                    {
                        stu = s;
                    }

                }
                Console.WriteLine($"Beste student : {stu.Name}\n");
            }

            static void worstStudent(List<student> students)
            {
                Console.WriteLine($"De slechtste student:\n");
                student stu = students[0];
                foreach (var s in students)
                {
                    if (stu.TotalDegree > s.TotalDegree)
                    {
                        stu = s;
                    }

                }
                Console.WriteLine($"slechtste student : {stu.Name}\n");
            }

            static void highestWebTech(List<student> students)
            {
                Console.WriteLine($"Welke student heeft de hoogste score voor Webtech\n");
                student stu = students[0];
                string name = "";
                int degreeH = 0;
                foreach (var item in students)
                {
                    foreach (var s in item.subject)
                    {
                        if (s.Name == "Webtech")
                        {
                            if (s.Degree > degreeH)
                            {
                                degreeH = s.Degree;
                                name = item.Name;
                            }
                        }
                    }
                }
                Console.WriteLine($"student : {name}\n");
            }

            static void highestSubjectStudent(List<student> students)
            {
                Console.WriteLine($"Welke student scoorde de hoogste waarde voor eender welk vak:\n");
                student stu = students[0];
                subject subj = stu.subject[0];
                foreach (var s in students)
                {
                    foreach (var item in s.subject)
                    {
                        if (item.Degree > subj.Degree)
                        {
                            stu = s;
                            subj = item;
                        }
                    }

                }
                Console.WriteLine($"student student : {stu.Name}\n");
            }

            static void passedStudent(List<student> students)
            {
                Console.WriteLine($"Wie is er allemaal geslaagd?\n");
                foreach (var s in students)
                {
                    Console.WriteLine($"student : {s.Name}\n");
                }

            }

            static void PhilippeScor(List<student> students)
            {
                Console.WriteLine($"Welke score heeft Philippe voor Webtech?\n");
                foreach (var s in students)
                {
                    if (s.Name == "Philippe")
                    {
                        foreach (var item in s.subject)
                        {
                            if (item.Name == "Webtech")
                            {
                                Console.WriteLine($"Philippe's score voor Webtech : {item.Degree}\n");
                            }
                        }
                    }

                }

            }

            static void PhilippeAverageScor(List<student> students)
            {
                Console.WriteLine($"Welke is de gemiddelde score van Philippe?\n");
                double sum = 0;
                foreach (var s in students)
                {
                    if (s.Name == "Philippe")
                    {
                        Console.WriteLine($"Philippe's gemiddelde score : {s.TotalDegree / s.subject.Count}\n");
                    }

                }

            }

            static void distinctionStudent(List<student> students)
            {
                Console.WriteLine($"Wie heeft onderscheiding?\n");
                foreach (var s in students)
                {
                    Console.WriteLine($"student : {s.Name}\n");
                }

            }

            static void LowAverage(List<student> students)
            {
                Console.WriteLine($"Welk vak heeft een klasgemiddeld van onder de 50%\n");
                foreach (var s in students)
                {
                    Console.WriteLine($"student : {s.Name}\n");
                }

            }

            static void reTake(List<student> students)
            {
                Console.WriteLine($"Wie heeft er allemaal herexamen?\n");
                foreach (var s in students)
                {
                    Console.WriteLine($"student : {s.Name}\n");
                }

            }

            static void ProgrammingReTake(List<student> students)
            {
                Console.WriteLine($"Wie heeft er allemaal herexamen voor Programmeren?\n");
                foreach (var s in students)
                {
                    foreach (var item in s.subject)
                    {
                        if (item.Name == "Programming" && item.Degree <= 12)
                        {
                            Console.WriteLine($"student : {s.Name}\n");
                        }
                    }
                }
            }

            static void MostReExams(List<student> students)
            {
                Console.WriteLine($"Welk vak heeft de meeste herexamens?\n");
                foreach (var s in students)
                {
                    foreach (var item in s.subject)
                    {
                        if (item.Degree < 12)
                        {
                            item.count++;
                        }
                    }
                }
                int count = 0;
                string name = "";
                foreach (var item in students)
                {
                    foreach (var suj in item.subject)
                    {
                        if (count < suj.count)
                        {
                            name = suj.Name;
                        }
                    }
                }
                Console.WriteLine($"Vak : {name}\n");
            }
        }
    }
}
