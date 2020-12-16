
using System.Collections.Generic;
namespace Amoozeshyar.Database
{
    public class Intern : DBObject,IPerson
    {
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Firstname { get ; set ; }
        public string Lastname { get ; set ; }
        public string gender { get ; set ; }
        public string Password { get ; set ; }
        public byte[] Salt { get ; set ; }
        public ICollection<PreRegistration> PreRegistrations { get; set; }
        public ICollection<FinancialTransaction> FinancialTransactions { get; set; }
        public ICollection<Register> Registers { get; set; }
    }
}