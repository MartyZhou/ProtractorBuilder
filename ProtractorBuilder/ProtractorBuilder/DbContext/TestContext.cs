using Microsoft.EntityFrameworkCore;
using ProtractorBuilder.Protractor.Common;

namespace ProtractorBuilder.Protractor.DbContext
{
    public class TestContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<TestModule> Modules
        {
            get;
            set;
        }

        public DbSet<TestSuite> Suites
        {
            get;
            set;
        }

        public DbSet<TestCase> Cases
        {
            get;
            set;
        }

        public DbSet<TestStep> Steps
        {
            get;
            set;
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<TestCase>()
        //                .HasMany(c => c.Steps)
        //                .WithOne();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=protractor.db");
		}
    }
}
