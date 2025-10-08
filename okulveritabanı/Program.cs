using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolGroupJoinExample
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int ClassId { get; set; }
    }

    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Öğrenci verileri
            List<Student> students = new List<Student>
            {
                new Student { StudentId = 1, StudentName = "Ali", ClassId = 1 },
                new Student { StudentId = 2, StudentName = "Ayşe", ClassId = 2 },
                new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 2 },
                new Student { StudentId = 4, StudentName = "Fatma", ClassId = 3 },
                new Student { StudentId = 5, StudentName = "Ahmet", ClassId = 1 }
            };

            // Sınıf verileri
            List<Class> classes = new List<Class>
            {
                new Class { ClassId = 1, ClassName = "Matematik" },
                new Class { ClassId = 2, ClassName = "Türkçe" },
                new Class { ClassId = 3, ClassName = "Kimya" }
            };

            // LINQ Group Join işlemi
            var groupJoinResult = from cls in classes
                                  join std in students on cls.ClassId equals std.ClassId into studentGroup
                                  select new
                                  {
                                      SinifAdi = cls.ClassName,
                                      Ogrenciler = studentGroup
                                  };

            // Sonuçları ekrana yazdır
            foreach (var item in groupJoinResult)
            {
                Console.WriteLine($"Sınıf: {item.SinifAdi}");
                foreach (var ogrenci in item.Ogrenciler)
                {
                    Console.WriteLine($" - {ogrenci.StudentName}");
                }
                Console.WriteLine(); // Boş satır
            }

            Console.ReadLine();
        }
    }
}
