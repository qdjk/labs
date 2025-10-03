using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{

    class University
    {
        public string Name { get; set; }
        public List<Faculty> Faculties { get; set; }

        public University(string name)
        {
            Name = name;
            Faculties = new List<Faculty>();
        }

    }
    class Faculty
    {
        public string Name { get; set; }
        public University University { get; set; }
        public List<Group> Groups { get; set; }
        public Faculty(string name, University university)
        {
            Name = name;
            University = university;
            Groups = new List<Group>();
        }
    }
    class Group
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public Faculty Faculty { get; set; }
        public Group(string name, Faculty faculty)
        {
            Name = name;
            Faculty = faculty;
            Students = new List<Student>();
        }
    }
    class Student
    {
        public string Name { get; set; }
        public double Score {  get; set; }
        public Group Group { get; set; }
        public Faculty Faculty
        {
            get
            {
                if (Group != null)
                {
                    return Group.Faculty;
                }
                else { return null; }
            }


        }
        public University University
        {
            get
            {
                if (Faculty != null)
                    return Faculty.University;
                else { return null; }
            }
        }

        public Student(string firstName, Group group,double score)
        {
            Name = firstName;
            Group = group;
            Score = score;
        }
    }
    


    internal class Program
    {
        static List<University> universities = new List<University>();
        static void Case()
        {
            while (true)
            {
                Console.WriteLine("1. Университеты");
                Console.WriteLine("2. Сохранение в файл");
                Console.WriteLine("3. Загрузить в файл");
                Console.WriteLine("4. Сохронить топ отличников среди институтов и групп");
                Console.WriteLine("0. Выход");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddUniver();
                        break;
                    case "2":
                        SaveToFileALL();
                        break;
                    case "3":
                        LoadFile();
                        break;
                    case "4":
                        SaveTop();
                        break;
                    case "0":
                        Console.WriteLine("Выход из программы");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор! Нажмите любую клавишу");
                        Console.ReadKey();
                        break;
                }
            }
        } 
        static void AddUniver()
        {
           
            while (true)
            {
                Console.WriteLine("Добавить университет? ");
                Console.WriteLine("1. Да");
                Console.WriteLine("2. Просмотреть все университеты");
                Console.WriteLine("0. Выйти в главное меню");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите название: ");
                        string Unname = Console.ReadLine();
                        University university = new University(Unname);
                        universities.Add(university);
                        break;
                    case "2":
                        Console.WriteLine("Все университеты: ");
                        for(int i=0;i<universities.Count;i++)
                        {
                            Console.WriteLine($"{i+1}. "+universities[i].Name);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Добавить факультет? ");
                        Console.WriteLine("1. Да");
                        Console.WriteLine("2. Нет");
                        int yn = Convert.ToInt32(Console.ReadLine());
                        if (yn == 1)
                        {
                            Console.WriteLine("Выберите институт: ");
                            for (int i = 0; i < universities.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. " + universities[i].Name);
                            }
                            int k = Convert.ToInt32(Console.ReadLine());
                            k = k - 1;
                            addFac(k);
                        }
                        else
                        {
                            Console.WriteLine("Удалить университет?");
                            Console.WriteLine("1. Да");
                            Console.WriteLine("2. Нет");
                            int yn1 = Convert.ToInt32(Console.ReadLine());
                            if (yn1 == 1)
                            {
                                Console.WriteLine("Выберите университет: ");
                                for (int i = 0; i < universities.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. " + universities[i].Name);
                                }
                                Console.WriteLine();
                                Console.WriteLine();

                                int numbstud = Convert.ToInt32(Console.ReadLine());
                                universities.RemoveAt(numbstud-1);
                            }

                        }

                        break ;
                    case "0":
                        Console.WriteLine("Выход в главное меню");
                        return;
                    
                }
            }
        }

        static void addFac(int k)
        {
            while (true)
            {
                Console.WriteLine("Добавить факультет? ");
                Console.WriteLine("1. Да");
                Console.WriteLine("2. Просмотреть все факультеты университета");
                Console.WriteLine("0. Выйти в главное меню");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите название нового факультета: ");
                        string FacName = Console.ReadLine();
                        Faculty faculty = new Faculty(FacName, universities[k]);
                        universities[k].Faculties.Add(faculty);
                        break;
                    case "2":
                        Console.WriteLine($"Все факультеты университета {universities[k]}: ");
                        for (int i = 0; i < universities[k].Faculties.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. " + universities[k].Faculties[i].Name);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Добавить группу? ");
                        Console.WriteLine("1. Да");
                        Console.WriteLine("2. Нет");
                        int yn = Convert.ToInt32(Console.ReadLine());
                        if (yn == 1)
                        {
                            Console.WriteLine("Выберите факультет: ");
                            for (int i = 0; i < universities[k].Faculties.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. " + universities[k].Faculties[i].Name);
                            }
                            int k1 = Convert.ToInt32(Console.ReadLine());
                            k1 = k1 - 1;
                            addGroup(k1,k);
                        }
                        else
                        {
                            Console.WriteLine("Удалить факультет?");
                            Console.WriteLine("1. Да");
                            Console.WriteLine("2. Нет");
                            int yn1 = Convert.ToInt32(Console.ReadLine());
                            if (yn1 == 1)
                            {
                                Console.WriteLine("Выберите факультет: ");
                                for (int i = 0; i < universities[k].Faculties.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. " + universities[k].Faculties[i].Name);
                                }
                                Console.WriteLine();
                                Console.WriteLine();

                                int numbstud = Convert.ToInt32(Console.ReadLine());
                                universities[k].Faculties.RemoveAt(numbstud-1);
                            }

                        }
                        break;
                    case "0":
                        Console.WriteLine("Выход в главное меню");
                        return;

                }
            }

        }
        static void addGroup(int k1,int k)
        {
            while (true)
            {
                Console.WriteLine("Добавить группу? ");
                Console.WriteLine("1. Да");
                Console.WriteLine("2. Просмотреть все группы факультета");
                Console.WriteLine("0. Выйти в главное меню");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите название новой группы: ");
                        string GroupName = Console.ReadLine();
                        Group group = new Group(GroupName, universities[k].Faculties[k1]);
                        universities[k].Faculties[k1].Groups.Add(group);
                        break;
                    case "2":
                        Console.WriteLine($"Все ГРУППЫ факультета {universities[k].Faculties[k1]}: ");
                        for (int i = 0; i < universities[k].Faculties[k1].Groups.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. " + universities[k].Faculties[k1].Groups[i].Name);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Добавить учеников группе? ");
                        Console.WriteLine("1. Да");
                        Console.WriteLine("2. Нет");
                        int yn = Convert.ToInt32(Console.ReadLine());
                        if (yn == 1)
                        {
                            Console.WriteLine("Выберите группу: ");
                            for (int i = 0; i < universities[k].Faculties[k1].Groups.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. " + universities[k].Faculties[k1].Groups[i].Name);
                            }
                            int k2 = Convert.ToInt32(Console.ReadLine());
                            k2 = k2 - 1;
                            addStud(k,k1,k2);
                        }
                        else
                        {
                            Console.WriteLine("Удалить группу?");
                            Console.WriteLine("1. Да");
                            Console.WriteLine("2. Нет");
                            int yn1 = Convert.ToInt32(Console.ReadLine());
                            if (yn1 == 1)
                            {
                                Console.WriteLine("Выберите группу: ");
                                for (int i = 0; i < universities[k].Faculties[k1].Groups.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. " + universities[k].Faculties[k1].Groups[i].Name);
                                }
                                Console.WriteLine();
                                Console.WriteLine();

                                int numbstud = Convert.ToInt32(Console.ReadLine());
                                universities[k].Faculties[k1].Groups.RemoveAt(numbstud-1);
                            }

                        }
                        break;
                    case "0":
                        Console.WriteLine("Выход в главное меню");
                        return;

                }
            }
        }
        static void addStud(int k,int k1,int k2)
        {
            while (true)
            {
                Console.WriteLine("Добавить студента? ");
                Console.WriteLine("1. Да");
                Console.WriteLine("2. Просмотреть всех студентов группы?");
                Console.WriteLine("0. Выйти в главное меню");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите имя студента: ");
                        string studName = Console.ReadLine();
                        Student student = new Student(studName, universities[k].Faculties[k1].Groups[k2],0);
                        universities[k].Faculties[k1].Groups[k2].Students.Add(student);
                        break;
                    case "2":
                        Console.WriteLine($"Все студенты группы {universities[k].Faculties[k1].Groups[k2]}: ");
                        for (int i = 0; i < universities[k].Faculties[k1].Groups[k2].Students.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. " + universities[k].Faculties[k1].Groups[k2].Students[i].Name);
                        }

                        Console.WriteLine();

                        Console.WriteLine("Указать средний балл студента? ");
                        Console.WriteLine("1. Да");
                        Console.WriteLine("2. Нет");
                        int yn = Convert.ToInt32(Console.ReadLine());
                        if (yn == 1)
                        {
                            Console.WriteLine("Выберите студента: ");
                            for (int i = 0; i < universities[k].Faculties[k1].Groups[k2].Students.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. " + universities[k].Faculties[k1].Groups[k2].Students[i].Name);
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                            
                            int numbstud = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Укажите средний балл студента!");
                            double scores = Convert.ToDouble(Console.ReadLine());
                            universities[k].Faculties[k1].Groups[k2].Students[numbstud-1].Score = scores;
                        }
                        else
                        {
                            Console.WriteLine("Удалить студента?");
                            Console.WriteLine("1. Да");
                            Console.WriteLine("2. Нет");
                            int yn1 = Convert.ToInt32(Console.ReadLine());
                            if (yn1 == 1)
                            {
                                Console.WriteLine("Выберите студента: ");
                                for (int i = 0; i < universities[k].Faculties[k1].Groups[k2].Students.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. " + universities[k].Faculties[k1].Groups[k2].Students[i].Name);
                                }
                                Console.WriteLine();
                                Console.WriteLine();

                                int numbstud = Convert.ToInt32(Console.ReadLine());
                                universities[k].Faculties[k1].Groups[k2].Students.RemoveAt(numbstud-1);
                            }

                        }
                        break;
                    case "0":
                        Console.WriteLine("Выход в главное меню");
                        return;

                }
            }
        }
        static void SaveToFileALL(string filePath = "C:\\Users\\M\\source\\repos\\lab1\\lab1\\file.txt")
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    foreach (var university in universities)
                    {
                        foreach (var faculty in university.Faculties)
                        {
                            foreach (var group in faculty.Groups)
                            {
                                foreach (var student in group.Students)
                                {
                                    string line = $"{university.Name} | {faculty.Name} | {group.Name} | {student.Name} | {student.Score:F2}";
                                    writer.WriteLine(line);
                                }
                            }
                        }
                    }
                }

                Console.WriteLine($"Данные успешно сохранены в файл: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
            }
        }
        static void LoadFile(string filePath = "C:\\Users\\M\\source\\repos\\lab1\\lab1\\load.txt")
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Файл {filePath} не найден!");
                    return;
                }

                // Очищаем текущие данные
                universities.Clear();

                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    string line;
                    bool isHeader = true;
                    int lineNumber = 0;

                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;
                        // Разделяем строку по разделителю "|"
                        var parts = line.Split('|').Select(p => p.Trim()).ToArray();

                        if (parts.Length >= 5)
                        {
                            string uniName = parts[0];
                            string facName = parts[1];
                            string groupName = parts[2];
                            string studentName = parts[3];
                            double score = double.Parse(parts[4]);

                            // Находим или создаем университет
                            var university = universities.FirstOrDefault(u => u.Name == uniName);
                            if (university == null)
                            {
                                university = new University(uniName);
                                universities.Add(university);
                            }

                            // Находим или создаем факультет
                            var faculty = university.Faculties.FirstOrDefault(f => f.Name == facName);
                            if (faculty == null)
                            {
                                faculty = new Faculty(facName, university);
                                university.Faculties.Add(faculty);
                            }

                            // Находим или создаем группу
                            var group = faculty.Groups.FirstOrDefault(g => g.Name == groupName);
                            if (group == null)
                            {
                                group = new Group(groupName, faculty);
                                faculty.Groups.Add(group);
                            }

                            // Создаем студента
                            var student = new Student(studentName, group, score);
                            group.Students.Add(student);
                        }
                        else
                        {
                            Console.WriteLine($"Ошибка формата в строке {lineNumber}: {line}");
                        }
                    }
                }

                Console.WriteLine($"Данные успешно загружены из файла: {filePath}");
                Console.WriteLine($"Загружено: {universities.Count} университетов");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке файла: {ex.Message}");
            }
        }
        static void SaveTop(string filePath = "C:\\Users\\M\\source\\repos\\lab1\\lab1\\top.txt")
        {
            try
            {
                if (universities.Count == 0)
                {
                    Console.WriteLine("Нет данных об университетах!");
                    return;
                }

                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    // Собираем статистику по институтам
                    var universityStats = new List<(string Name, int Count)>();

                    foreach (var university in universities)
                    {
                        int excellentCount = 0;

                        foreach (var faculty in university.Faculties)
                        {
                            foreach (var group in faculty.Groups)
                            {
                                excellentCount += group.Students.Count(student => student.Score > 4.5);
                            }
                        }

                        universityStats.Add((university.Name, excellentCount));
                    }

                    // Находим институт с максимальным количеством отличников
                    var topUni = universityStats.OrderByDescending(u => u.Count).FirstOrDefault();

                    // Собираем статистику по группам
                    var groupStats = new List<(string Uni, string Fac, string Grp, int Count)>();

                    foreach (var university in universities)
                    {
                        foreach (var faculty in university.Faculties)
                        {
                            foreach (var group in faculty.Groups)
                            {
                                int excellentCount = group.Students.Count(student => student.Score > 4.5);
                                groupStats.Add((university.Name, faculty.Name, group.Name, excellentCount));
                            }
                        }
                    }

                    // Находим группу с максимальным количеством отличников
                    var topGrp = groupStats.OrderByDescending(g => g.Count).FirstOrDefault();

                    if (topUni.Count > 0)
                    {
                        writer.WriteLine($"{topUni.Name} | {topUni.Count}");
                    }
                    else
                    {
                        writer.WriteLine("Нет отличников | 0");
                    }

                    if (topGrp.Count > 0)
                    {writer.WriteLine($"{topGrp.Grp} | {topGrp.Count}");}
                    else
                    {
                        writer.WriteLine("Нет отличников | 0");
                    }
                }

                Console.WriteLine($"Файл с топом отличников создан: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        static void Main(string[] args)
        {
            Case();
        }   

    }

}