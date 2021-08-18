using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string School { get; set; }
        public string Grade { get; set; }
        public string DesiredUniversity { get; set; }
        public string PhoneNumber { get; set; }
        
        //navigation property
        public List<Lesson> Lessons { get; set; }
        public override string ToString()
        {
            return $"{FirstName + " " + LastName} School: {School} - Grade: {Grade} - DesiredUniversity: {DesiredUniversity}";
        }
    }
}
