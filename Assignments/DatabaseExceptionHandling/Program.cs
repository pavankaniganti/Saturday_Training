using Microsoft.Extensions.Configuration;
using System;
using System.IO;

using DatabaseExceptionHandling.DataAccessLayer;

namespace DatabaseExceptionHandling
{
    class Program
    {
        private static IConfiguration _iconfiguration;
        static void Main(string[] args)
        {
           
            ShowStudents();
            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();
        }
       
        static void ShowStudents()
        {
            var studentDal = new StudentDal(_iconfiguration);
            var lstStudent = studentDal.GetAllStudents();
            lstStudent.ForEach(item =>
            {
                Console.WriteLine($"StudentID: {item.StudentID}" +
                    $" Name: {item.Name}" +
                    $" Grp Name: {item.GroupName}" +
                    $" Date: {item.ModifiedDate.ToShortDateString()}");
            });
        }
    }
}
