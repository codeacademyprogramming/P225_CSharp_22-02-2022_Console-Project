using System;
using System.Collections.Generic;
using System.Text;
using CourseManagement.Enums;
using CourseManagement.Models;
using CourseManagement.Interfaces;

namespace CourseManagement.Services
{
    class CourseManagementService : ICourseManagementService
    {
        private Group[] _groups;
        public Group[] Groups => _groups;

        public CourseManagementService()
        {
            _groups = new Group[0];
        }

        public void AddGroup(int limit, GroupType groupType)
        {
            Group group = new Group(limit, groupType);
            Array.Resize(ref _groups, _groups.Length + 1);
            _groups[_groups.Length - 1] = group;
        }

        public void AddStudent(string groupNo, string name, string surname, StudemtType studemtType, bool isOnline)
        {
            Group group = FindGroup(groupNo);

            if (group != null)
            {
                Student student = new Student(name, surname, studemtType, groupNo, isOnline);
                group.AddStudent(student);
                return;
            }
            else
            {
                Console.WriteLine($"Daxil Etdiynmiz Qrup Nomresi = {groupNo} Tapilmadi");
            }
        }

        public void EditGroup(string groupNo, int limit, GroupType groupType)
        {
            Group group = FindGroup(groupNo);

            if (group != null)
            {
                group.Limit = limit;
                group.GroupType = groupType;
                group.No =  group.No.Replace(group.No[0],groupType.ToString()[0]);

                foreach (Student item in group.GetStudents())
                {
                    if (item != null)
                    {
                        item.GroupName = group.No;
                    }
                }

                Console.WriteLine("Telebe Ugurla Editlendi Edildi");
                return;
            }
            else
            {
                Console.WriteLine($"Daxil Etdiynmiz Qrup Nomresi = {groupNo} Tapilmadi");
            }
        }

        public Student[] GetStudentsByGroupName(string groupNo)
        {
            Group group = FindGroup(groupNo);

            if (group !=  null)
            {
                return group.GetStudents();
            }

            return null;
        }

        public Student[] SearchStudent(string search)
        {
            Student[] students = new Student[0];

            foreach (Group group in _groups)
            {
                if (group != null)
                {
                    foreach (Student student in group.GetStudents())
                    {
                        if (student != null && 
                            (student.Name.ToLower().Contains(search.ToLower()) || 
                            student.SurName.ToLower().Contains(search.ToLower()) || 
                            student.GroupName.ToLower().Contains(search.ToLower()) || 
                            student.StudemtType.ToString().ToLower().Contains(search.ToLower())))
                        {
                            Array.Resize(ref students, students.Length + 1);
                            students[students.Length - 1] = student;
                        }
                    }
                }
            }

            return students;
        }

        private Group FindGroup(string groupNo)
        {
            foreach (Group item in _groups)
            {
                if (item.No.ToLower() == groupNo.ToLower())
                {
                    return item;
                }
            }

            return null;
        }
    }
}
