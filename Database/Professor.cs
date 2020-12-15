using System.Collections.Generic;

namespace Amoozeshyar.Database
{
    public class Professor : DBObject,IPerson
    {
        public string Mobile { get; set; }
        public string Firstname { get ; set ; }
        public string Lastname { get ; set ; }
        public string gender { get ; set ; }
        public string Address { get ; set ; }
        public string Field { get; set; }
        public string Password { get; set; }
        public ICollection<Course> Courses { get; set; }
        
    
    }
}