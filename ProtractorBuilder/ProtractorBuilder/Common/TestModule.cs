using System.Collections.Generic;

namespace ProtractorBuilder.Protractor.Common
{
    public class TestModule : TestStepWrapper
    {
        public List<TestSuite> Suites { get; set; }
    }
}
