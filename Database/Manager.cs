using System.Collections.Generic;

namespace Amoozeshyar.Database
{
    public class Manager : DBObject, IPerson
    {
        public string Firstname { get ; set ; }
        public string Lastname { get ; set ; }
        public string gender { get ; set ; }
        public string Mobile { get ; set; }
        public string Address { get; set; }
        public string Password { get ; set ; }
        public byte[] Salt { get; set ; }
        public ICollection<Course> Courses { get; set; }
    }
}