using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
    internal class SportStudent:Student
    {
        public override void GetStaff()
        {
            Console.WriteLine($" I am {Name}, I get sport uniform"); 
        }
        public override void Study()
        {
            Console.WriteLine($"At the lesson i do sport");
        }
    
    }
}
