using System.Linq;
using App.Models;

namespace App
{
    public class SampleData
    {
        public static void Initialize(StudDbContext context)
        {
            if (!context.Students.Any())
            {
                context.Students.AddRange(
                    new Student
                    {
                        FirstName = "iPhone X",
                        LastNAme = "Apple",
                        MiddleName = "leon",
                        Sex = "муж",
                        CallName = "dfgdfg"
                    },
                     new Student
                     {
                         FirstName = "iPhone X",
                         LastNAme = "Apple",
                         MiddleName = "leon",
                         Sex = "жен",
                         CallName = "dfgdfg"
                     }
                );
                context.SaveChanges();
            }
        }
    }
}

