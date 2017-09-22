using System.Collections.Generic;

namespace ProtractorBuilder.Protractor.Common
{
    public class TestSuite : TestStepWrapper
    {
        public List<TestCase> Cases { get; set; }
    }
}
