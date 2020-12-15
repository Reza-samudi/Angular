using System.Collections.Generic;

namespace Amoozeshyar.Database
{
    public class Field : DBObject
    {
        public string Title { get; set; }
        public int TheoryHours { get; set; }
        public int PracticalHours { get; set; }
        public ICollection<PreRegistration> PreRegistrations { get; set; }
        public ICollection<Course> Courses { get; set; }
        
        
        
    }
}