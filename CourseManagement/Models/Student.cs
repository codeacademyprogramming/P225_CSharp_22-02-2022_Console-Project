using System;
using System.Collections.Generic;
using System.Text;
using CourseManagement.Enums;

namespace CourseManagement.Models
{
    class Student
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public StudemtType StudemtType { get; set; }
        public string GroupName { get; set; }
        public bool IsOnline { get; set; }

        public Student(string name, string surName, StudemtType studemtType, string groupName, bool isOnline)
        {
            Name = name;
            SurName = surName;
            StudemtType = studemtType;
            GroupName = groupName;
            IsOnline = isOnline;
        }

        public override string ToString()
        {
            string waranty = (int)StudemtType == 1 ? "Zemanetli" : "Zemanetsiz";
            string online = IsOnline ? "Online" : "Ofline";
            return $"Ad: {Name}\nSoyAd: " +
                $"{SurName}\nZemanet Novu: " +
                $"{waranty}\nQrup Nomresi: " +
                $"{GroupName}\nTehsil Novu:{online}";
        }
    }
}
