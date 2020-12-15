namespace Amoozeshyar.Database
{
    public class FinancialTransaction:DBObject
    {
        public Intern Intern { get; set; }
        public int InternId { get; set; }
        public double DebtAmount { get; set; } //bedhi
        public double CreditAmount { get; set; } //bestankari
        public string About { get; set; } // hazine baraye chi bode  
    }
}