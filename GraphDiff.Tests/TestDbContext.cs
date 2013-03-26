using System.Data.Entity;
using GraphDiff.Tests.Models;

namespace GraphDiff.Tests
{
    public class TestDbContext : DbContext
    {
        public IDbSet<Company> Companies { get; set; }
        public IDbSet<CompanyContact> CompanyContacts { get; set; }
        public IDbSet<Project> Projects { get; set; }
        public IDbSet<Manager> Managers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasMany(p => p.Contacts).WithRequired().WillCascadeOnDelete(true);
            modelBuilder.Entity<CompanyContact>().HasMany(p => p.Infos).WithRequired().WillCascadeOnDelete(true);
            modelBuilder.Entity<Project>().HasMany(p => p.Stakeholders).WithMany();
            base.OnModelCreating(modelBuilder);
        }
    }
}
