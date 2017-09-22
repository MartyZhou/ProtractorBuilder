using Microsoft.EntityFrameworkCore;
using ProtractorBuilder.Protractor.Common;

namespace ProtractorBuilder.Protractor.DbContext
{
    public class TestContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options) { }

        public DbSet<TestModule> Modules { get; set; }

        public DbSet<TestSuite> Suites { get; set; }

        public DbSet<TestCase> Cases { get; set; }

        public DbSet<TestStep> Steps { get; set; }

        public DbSet<TestModuleSuite> ModulesSuites { get; set; }

        public DbSet<TestSuiteCase> SuitesCases { get; set; }

        public DbSet<TestCaseStep> CasesSteps { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestModuleSuite>().HasKey(c => new { c.TestModuleId, c.TestSuiteId });
            modelBuilder.Entity<TestSuiteCase>().HasKey(c => new { c.TestSuiteId, c.TestCaseId });
            modelBuilder.Entity<TestCaseStep>().HasKey(c => new { c.TestCaseId, c.TestStepId });
        }
    }
}
