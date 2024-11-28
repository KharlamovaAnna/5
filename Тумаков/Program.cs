using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Файлик
{
    internal class Program
    {
        public class Student
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public int BirthYear { get; set; }
            public string EntranceExam { get; set; }
            public int Score { get; set; }

            public Student(string lastName, string firstName, int birthYear, string entranceExam, int score)
            {
                LastName = lastName;
                FirstName = firstName;
                BirthYear = birthYear;
                EntranceExam = entranceExam;
                Score = score;
            }

            public override string ToString()
            {
                return $"{LastName} {FirstName}, {BirthYear}, {EntranceExam}, {Score}";
            }
        }

        public class StudentManager
        {
            private List<Student> students;

            public StudentManager()
            {
                students = new List<Student>();
            }

            public void LoadStudentsFromFile(string filePath)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(',');
                            if (parts.Length == 5)
                            {
                                students.Add(new Student(parts[0].Trim(), parts[1].Trim(), int.Parse(parts[2].Trim()), parts[3].Trim(), int.Parse(parts[4].Trim())));
                            }
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Файл с данными о студентах не найден.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                }
            }

            public void AddNewStudent()
            {
                Console.WriteLine("Введите данные нового студента:");
                Console.Write("Фамилия: ");
                string lastName = Console.ReadLine();
                Console.Write("Имя: ");
                string firstName = Console.ReadLine();
                Console.Write("Год рождения: ");
                int birthYear = int.Parse(Console.ReadLine());
                Console.Write("Экзамен: ");
                string entranceExam = Console.ReadLine();
                Console.Write("Балл: ");
                int score = int.Parse(Console.ReadLine());
                students.Add(new Student(lastName, firstName, birthYear, entranceExam, score));
                Console.WriteLine("Студент добавлен.");
            }

            public void RemoveStudent()
            {
                Console.Write("Введите фамилию студента: ");
                string lastName = Console.ReadLine();
                Console.Write("Введите имя студента: ");
                string firstName = Console.ReadLine();
                Student studentToRemove = students.FirstOrDefault(s => s.LastName == lastName && s.FirstName == firstName);
                if (studentToRemove != null)
                {
                    students.Remove(studentToRemove);
                    Console.WriteLine("Студент удален.");
                }
                else
                {
                    Console.WriteLine("Студент не найден.");
                }
            }

            public void SortStudentsByScore()
            {
                students.Sort((s1, s2) => s1.Score.CompareTo(s2.Score));
                Console.WriteLine("Студенты отсортированы по баллам.");
            }

            public void PrintStudents()
            {
                Console.WriteLine("Список студентов:");
                foreach (Student student in students)
                {
                    Console.WriteLine(student);
                }
            }
     
    
        static void Main(string[] args)
            {
                /*Создать студента из вашей группы (фамилия, имя, год рождения, с каким экзаменом
                поступил, баллы). Создать словарь для студентов из вашей группы (10 человек).*/
                Console.WriteLine("Задание 2");

                StudentManager manager = new StudentManager();
                manager.LoadStudentsFromFile("students.txt"); //он не читает данные с файла, и я не знаю почему :(

                string command;
                do
                {
                    Console.WriteLine("Меню:");
                    Console.WriteLine("a. Новый студент");
                    Console.WriteLine("b. Удалить студента");
                    Console.WriteLine("c. Сортировать по баллам");
                    Console.WriteLine("d. Вывести список студентов");
                    Console.WriteLine("e. Выход");
                    Console.Write("Введите команду: ");
                    command = Console.ReadLine().ToLower();

                    switch (command)
                    {
                        case "a": manager.AddNewStudent();
                            break;
                        case "b": manager.RemoveStudent();
                            break;
                        case "c": manager.SortStudentsByScore();
                            break;
                        case "d": manager.PrintStudents(); 
                            break;
                        case "e": Console.WriteLine("Выход...");
                            break;
                        default: Console.WriteLine("Неверная команда.");
                            break;
                    }
                }
                while (command != "e");
                Console.ReadLine();
            }
        }
        }
    }

