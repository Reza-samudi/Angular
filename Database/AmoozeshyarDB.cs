using Microsoft.EntityFrameworkCore;

namespace Amoozeshyar.Database
{
    public class AmoozeshyarDB : DbContext
    {
        public DbSet<Field> Fields { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
        public DbSet<Intern> Interns { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<PreRegistration> PreRegistrations { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Register> Registers { get; set; }
        public AmoozeshyarDB(DbContextOptions<AmoozeshyarDB> options)
            :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) /*وقتی داری دیتابیس را می سازی با این مدلی که من می خوام بساز*/
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Intern>()
                .HasIndex(m=>m.Mobile) //یه نفر فقط با شماره موبایل موجود ثبت کند.
                .IsUnique(true);
        }

    }
}