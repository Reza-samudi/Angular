namespace Amoozeshyar.Database
{
    public class Register :DBObject
    {
        public Intern Intern { get; set; }
        public int InternId { get; set; }
        public Course Course { get; set; } // yani che doreye ba kodam ostad che saati hamye vizhegihaye course
        public int CourseId { get; set; } 
        public RegisterStatus Status { get; set; }
        
        
    }
    public enum RegisterStatus 
    {
        FinancialProblem,
        Forbided,
        Normal
        
    }
}