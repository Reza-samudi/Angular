using System.Collections.Generic;

namespace Amoozeshyar.Database
{
    public class Manager : DBObject, IPerson
    {
        string IPerson.Firstname { get ; set ; }
        string IPerson.Lastname { get ; set ; }
        string IPerson.gender { get ; set ; }
        string IPerson.Mobile { get ; set ; }
        string IPerson.Address { get ; set ; }
        string IPerson.Password { get ; set; }
        public ICollection<Course> Courses { get; set; }
    }
}