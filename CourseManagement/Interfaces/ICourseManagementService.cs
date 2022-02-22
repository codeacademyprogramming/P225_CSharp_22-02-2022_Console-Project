using System;
using System.Collections.Generic;
using System.Text;
using CourseManagement.Models;
using CourseManagement.Enums;

namespace CourseManagement.Interfaces
{
    interface ICourseManagementService
    {
        Group[] Groups { get; }
        void AddGroup(int limit, GroupType groupType);
        void EditGroup(string groupNo, int limit, GroupType groupType);
        void AddStudent(string groupNo, string name, string surname,StudemtType studemtType, bool isOnline);
        Student[] GetStudentsByGroupName(string groupNo);
        Student[] SearchStudent(string search);
    }
}
