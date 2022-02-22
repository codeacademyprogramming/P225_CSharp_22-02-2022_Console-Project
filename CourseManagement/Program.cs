using CourseManagement.Enums;
using CourseManagement.Models;
using CourseManagement.Services;
using System;

namespace CourseManagement
{
    class Program
    {
        static void Main(string[] args)
        {

            //string groupNo = Console.ReadLine();

            //Console.WriteLine(string.IsNullOrWhiteSpace(groupNo));

            CourseManagementService courseManagementService = new CourseManagementService();

            do
            {
                Console.WriteLine("Seciminizi Edin");
                Console.WriteLine("1. Qrup yarat");
                Console.WriteLine("2. Qrup Yenile");
                Console.WriteLine("3. Telebe yarat");
                Console.WriteLine("4. Qrupunu Telebelerini Gosder");
                Console.WriteLine("5. Telebe Axtarisi");
                Console.WriteLine("6. Sistem Cixis");

                string str = Console.ReadLine();
                int changed;

                while (!int.TryParse(str, out changed) || changed < 1 || changed > 6)
                {
                    Console.WriteLine("Duzgun Secim Edin");
                    str = Console.ReadLine();
                }

                switch (changed)
                {
                    case 1:
                        AddGroup(ref courseManagementService);
                        break;
                    case 2:
                        EditGroup(ref courseManagementService);
                        break;
                    case 3:
                        AddStudent(ref courseManagementService);
                        break;
                    case 4:
                        GetStudentsByGroupName(ref courseManagementService);
                        break;
                    case 5:
                        SearchStudent(ref courseManagementService);
                        break;
                    case 6:
                        Console.WriteLine("Tesekkurler Sagolun");
                        return;
                }

            } while (true);
        }

        public static void AddGroup(ref CourseManagementService courseManagementService)
        {
            Console.WriteLine("Qrupun Limitini Daxil Et");
            string groupLimitstr = Console.ReadLine();
            int groupLimit;

            while (!int.TryParse(groupLimitstr, out groupLimit) || groupLimit > 18 || groupLimit < 0)
            {
                Console.WriteLine("Duzgun Limit Daxil Et");
                groupLimitstr = Console.ReadLine();
            }

            Console.WriteLine("Qrup Novunu Sec");
            foreach (var item in Enum.GetValues(typeof(GroupType)))
            {
                Console.WriteLine($"{(int)item} {item}");
            }

            string groupTypeStr = Console.ReadLine();
            int groupTypeNum;

            while (!int.TryParse(groupTypeStr, out groupTypeNum) || groupTypeNum < 1 || groupTypeNum > 3)
            {
                Console.WriteLine("Duzgun Qrup Novu Sec:");
                groupTypeStr = Console.ReadLine();
            }

            GroupType groupType  = (GroupType)groupTypeNum;

            courseManagementService.AddGroup(groupLimit, groupType);

            Console.WriteLine("Qrup Ugurla yarandi");
        }

        static void EditGroup(ref CourseManagementService courseManagementService)
        {
            if (courseManagementService.Groups.Length > 0)
            {
                Console.WriteLine("Qrupun Nomresini Daxil Et");
                foreach (Group group in courseManagementService.Groups)
                {
                    Console.WriteLine(group);
                }
            }
            else
            {
                Console.WriteLine("Once Qrup Yarat");
                return;
            }

            string groupNo = Console.ReadLine();

            Console.WriteLine("Qrupun Limitini Daxil Et");
            string groupLimitstr = Console.ReadLine();
            int groupLimit;

            while (!int.TryParse(groupLimitstr, out groupLimit) || groupLimit > 18 || groupLimit < 0)
            {
                Console.WriteLine("Duzgun Limit Daxil Et");
                groupLimitstr = Console.ReadLine();
            }

            Console.WriteLine("Qrup Novunu Sec");
            foreach (var item in Enum.GetValues(typeof(GroupType)))
            {
                Console.WriteLine($"{(int)item} {item}");
            }

            string groupTypeStr = Console.ReadLine();
            int groupTypeNum;

            while (!int.TryParse(groupTypeStr, out groupTypeNum) || groupTypeNum < 1 || groupTypeNum > 3)
            {
                Console.WriteLine("Duzgun Qrup Novu Sec:");
                groupTypeStr = Console.ReadLine();
            }

            GroupType groupType = (GroupType)groupTypeNum;

            courseManagementService.EditGroup(groupNo,groupLimit, groupType);

            Console.WriteLine("Qrup Ugurla Yenilendi");
        }

        static void AddStudent(ref CourseManagementService courseManagementService)
        {
            if (courseManagementService.Groups.Length > 0)
            {
                Console.WriteLine("Qrupun Nomresini Daxil Et");
                foreach (Group group in courseManagementService.Groups)
                {
                    Console.WriteLine(group);
                }
            }
            else
            {
                Console.WriteLine("Once Qrup Yarat");
                return;
            }

            string groupNo = Console.ReadLine();

            Console.WriteLine("Telebenin Adnini Daxil Et");
            string studnetName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(studnetName))
            {
                Console.WriteLine("Telebenin Adnini Duzgun Daxil Et");
                studnetName = Console.ReadLine();
            }

            Console.WriteLine("Telebenin SoyAdnini Daxil Et");
            string studnetSurName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(studnetSurName))
            {
                Console.WriteLine("Telebenin SoyAdnini Duzgun Daxil Et");
                studnetSurName = Console.ReadLine();
            }

            Console.WriteLine("Telebeinin Zemanet Novunu Sec");
            foreach (var item in Enum.GetValues(typeof(StudemtType)))
            {
                Console.WriteLine($"{(int)item} {item}");
            }

            string studentTypeStr = Console.ReadLine();
            int studentTypeNum;

            while (!int.TryParse(studentTypeStr, out studentTypeNum) || studentTypeNum < 1 || studentTypeNum > 2)
            {
                Console.WriteLine("Telebenini Zemanet Novunu Duzgun Sec:");
                studentTypeStr = Console.ReadLine();
            }

            StudemtType studemtType = (StudemtType)studentTypeNum;
            Console.WriteLine("Telebe Onlinedirmi y/n");
            string isOnlineStr = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(isOnlineStr) || isOnlineStr != "y" && isOnlineStr != "n")
            {
                Console.WriteLine("Telebe Onlinedirmi Duzgun Secim Et y/n");
                isOnlineStr = Console.ReadLine();
            }

            bool isOnlen = isOnlineStr == "y" ? true : false;

            courseManagementService.AddStudent(groupNo, studnetName, studnetSurName, studemtType, isOnlen);

            Console.WriteLine("Telebe Ugurla Yaradildi");
        }

        static void GetStudentsByGroupName(ref CourseManagementService courseManagementService)
        {
            if (courseManagementService.Groups.Length > 0)
            {
                Console.WriteLine("Qrupun Nomresini Daxil Et");
                foreach (Group group in courseManagementService.Groups)
                {
                    Console.WriteLine(group);
                }
            }
            else
            {
                Console.WriteLine("Once Qrup Yarat");
                return;
            }

            string groupNo = Console.ReadLine();

            foreach (Student student in courseManagementService.GetStudentsByGroupName(groupNo))
            {
                if (student != null)
                {
                    Console.WriteLine(student);
                }
            }
        }

        static void SearchStudent(ref CourseManagementService courseManagementService)
        {
            Console.WriteLine("Axtaris Ucun Kelimeni Daxil Et:");
            string search = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(search))
            {
                Console.WriteLine("Axtaris Ucun Duzgun Kelimeni Daxil Et:");
                search = Console.ReadLine();
            }

            foreach (Student student in courseManagementService.SearchStudent(search))
            {
                if (student != null)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}
