namespace Amoozeshyar.Database
{
    public class PreRegistration :DBObject
    {
        public Intern Intern { get; set; }
        public int InternId { get; set; }
        public Field Field { get; set; }
        public int FieldId { get; set; }
        public StatusTypes Status { get; set; }
    }
    public enum StatusTypes {
        WaitingForPrePay,
        PrePaid, /*pishpardakht shode*/
        Canceled,
        Registred
    }
}