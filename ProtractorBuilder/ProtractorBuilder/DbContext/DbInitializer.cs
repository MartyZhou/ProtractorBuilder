using System.Linq;
using ProtractorBuilder.Protractor.Common;

namespace ProtractorBuilder.Protractor.DbContext
{
    public static class DbInitializer
    {
        public static void Initialize(TestContext context)
        {
            context.Database.EnsureCreated();

            if (context.Modules.Any())
            {
                return;
            }

            var steps = new TestStep[]
            {
                new TestStep{Id="1", ActionSequence=ActionSequence.loadUrl, Name="Go to google", Order=0, Value="http://google.com"},
                new TestStep{Id="2", ActionSequence=ActionSequence.wait, Name="Wait for 10 seconds", Order=1, Value="10"}
            };

            context.Steps.AddRange(steps);

            var cases = new TestCase[]
            {
                new TestCase{Id="1", Enabled=true, Name="Google Case", Order=0, TestCaseType=TestCaseType.Normal}
            };

            context.Cases.AddRange(cases);

            var casesSteps = new TestCaseStep[]
            {
                new TestCaseStep{TestCaseId="1", TestStepId="1"},
                new TestCaseStep{TestCaseId="1", TestStepId="2"}
            };

            context.CasesSteps.AddRange(casesSteps);

            var suites = new TestSuite[]
            {
                new TestSuite{Id="1", Enabled=true, Name="Google Suite", Order=0}
            };

            context.Suites.AddRange(suites);

            var suitesCases = new TestSuiteCase[]
            {
                new TestSuiteCase{TestSuiteId="1", TestCaseId="1"}
            };

            context.SuitesCases.AddRange(suitesCases);

            var modules = new TestModule[]
            {
                new TestModule{Id="1", Enabled=true, Name="Google Module", Order=1}
            };

            context.Modules.AddRange(modules);

            var modulesSuites = new TestModuleSuite[]
            {
                new TestModuleSuite{TestModuleId="1", TestSuiteId="1"}
            };

            context.ModulesSuites.AddRange(modulesSuites);

            context.SaveChanges();
        }
    }
}
