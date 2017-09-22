using System.Collections.Generic;

namespace ProtractorBuilder.Protractor.Common
{
    public class TestCase : TestStepWrapper
    {
        public TestCaseType TestCaseType { get; set; }

        public string Log { get; set; }

        public List<TestStep> Steps { get; set; }
    }
}
