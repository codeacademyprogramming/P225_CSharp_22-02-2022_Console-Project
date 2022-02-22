using System;
using System.Collections.Generic;
using System.Text;
using CourseManagement.Enums;

namespace CourseManagement.Models
{
    class Group
    {
        private static int _count = 100;
        public string No { get; set; }
        private Student[] Students;
        public int Limit { get; set; }
        public GroupType GroupType { get; set; }

        public Group(int limit, GroupType groupType)
        {
            Students = new Student[0];
            _count++;
            GroupType = groupType;
            Limit = limit;
            No = $"{GroupType.ToString()[0]}{_count}";
        }

        public void AddStudent(Student student)
        {
            if (Students.Length < Limit)
            {
                Array.Resize(ref Students, Students.Length + 1);
                Students[Students.Length - 1] = student;
            }
            else
            {
                Console.WriteLine("Groupda Yer Yoxdur");
            }
        }

        public Student[] GetStudents() => Students;

        public override string ToString()
        {
            return $"Qroup Nomresi: {No}\nQrup Limiti: {Limit}\nQrupun Novu: {GroupType}";
        }
    }
}
