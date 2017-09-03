using System.Collections.Generic;

namespace ProtractorBuilder.Protractor.Common
{
    public class TestCase : TestStepWrapper
    {
        public string Log
        {
            get;
            set;
        }

        public List<TestStep> Steps
        {
            get;
            set;
        }
    }
}
