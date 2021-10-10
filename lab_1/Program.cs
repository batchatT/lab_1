using System;
using System.Linq;
namespace lb1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool wannaExit = false;
            Menu choise = 0;
            Student[] students = new Student[10];
            int nStudents = 0;
            while (wannaExit != true)
            {
                int i = 0;
                Console.WriteLine("Оберiть пункт меню: ");
                foreach (string item in Enum.GetNames(typeof(Menu)))
                {
                    Console.WriteLine($"{i++}. {item}");
                }
                Console.WriteLine("Що Ви хочете зробити? >>> ");
                choise = (Menu)int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case Menu.AddStudent:
                        {
                            Console.WriteLine("Введiть ПIБ студента: ");
                            string name = Console.ReadLine();
                            Console.WriteLine($"Введiть номер залiкової книжки студента {name}: ");
                            string id = Console.ReadLine();
                            Console.WriteLine($"Введiть курс студента {name}: ");
                            int course = int.Parse(Console.ReadLine());
                            Student stud = new Student(name, id, course);
                            students[nStudents++] = stud;
                            break;
                        }
                    case Menu.SetMarks:
                        {
                            i = 0;
                            Console.WriteLine("Оберiть який студент має отримати оцiнку: ");
                            foreach (var student in students)
                            {
                                if (students[i] != null) Console.WriteLine($"{i++}. {student.Name}");
                            }
                            var choosenStudent = students[int.Parse(Console.ReadLine())];
                            Console.WriteLine("Оберiть з якого предмету додати оцiнку: ");
                            i = 0;
                            foreach (string subject in Enum.GetNames(typeof(Subjects)))
                            {
                                Console.WriteLine($"{i++}. {subject}");
                            }
                            var choosenSubject = (Subjects)int.Parse(Console.ReadLine());
                            Console.WriteLine("Введiть оцiнку: ");
                            choosenStudent.SetMark(choosenSubject, int.Parse(Console.ReadLine()));
                            break;
                        }
                    case Menu.GetMarks:
                        {
                            i = 0;
                            Console.WriteLine("Оберiть студента для виведення оцiнки: ");
                            foreach (var student in students)
                            {
                                if (students[i] != null) Console.WriteLine($"{i++}. {student.Name}");
                            }
                            var choosenStudent = students[int.Parse(Console.ReadLine())];
                            Console.WriteLine("Оберiть з якого предмету вивести оцiнку: ");
                            i = 0;
                            foreach (string subject in Enum.GetNames(typeof(Subjects)))
                            {
                                Console.WriteLine($"{i++}. {subject}");
                            }
                            var choosenSubject = (Subjects)int.Parse(Console.ReadLine());
                            Console.WriteLine($"Оцiнка: {choosenStudent.GetMark(choosenSubject)}");
                            break;
                        }
                    case Menu.CompareStudents:
                        {
                            i = 0;
                            Console.WriteLine("Оберiть двох студентiв для порiвняння за iндексами: ");
                            foreach (var student in students)
                            {
                                if (students[i] != null) Console.WriteLine($"{i++}. {student.Name}");
                            }
                            var chosenStudent1 = students[int.Parse(Console.ReadLine())];
                            Console.WriteLine($"Перший студент для порiвняння: {chosenStudent1.ToString()}");
                            var chosenStudent2 = students[int.Parse(Console.ReadLine())];
                            Console.WriteLine($"Другий студент для порiвняння: {chosenStudent2.ToString()}");
                            Console.WriteLine("Результат порiвняння оцiнок студентiв: ");
                            i = 0;
                            foreach (string subject in Enum.GetNames(typeof(Subjects)))
                            {
                                Console.WriteLine($"{i}. {subject}");
                                Console.WriteLine($"Перший: {chosenStudent1.GetMark((Subjects)Enum.Parse(typeof(Subjects), subject))}");
                                Console.WriteLine($"Другий: {chosenStudent2.GetMark((Subjects)Enum.Parse(typeof(Subjects), subject))}");
                                Console.WriteLine($"Рiзниця: {chosenStudent1.CompareTo(chosenStudent2)[i++]}");
                            }
                            break;
                        }
                    case Menu.ShowInfo:
                        {
                            i = 0;
                            Console.WriteLine("Оберiть студента за iндексом: ");
                            foreach (var student in students)
                            {
                                if (students[i] != null) Console.WriteLine($"{i++}. {student.Name}");
                            }
                            Console.WriteLine(students[int.Parse(Console.ReadLine())].ToString());
                            break;
                        }

                }



            }
        }
    }
    enum Menu
    {
        AddStudent,
        SetMarks,
        GetMarks,
        CompareStudents,
        ShowInfo
    }
}
