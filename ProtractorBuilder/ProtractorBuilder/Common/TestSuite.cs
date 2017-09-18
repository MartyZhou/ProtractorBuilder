using System.Collections.Generic;

namespace ProtractorBuilder.Protractor.Common
{
    public class TestSuite : TestStepWrapper
    {
        public List<TestStep> BeforeAll
        {
            get;
            set;
        }

        public List<TestStep> AfterAll
        {
            get;
            set;
        }

        public List<TestStep> BeforeEach
        {
            get;
            set;
        }
       
        public List<TestStep> AfterEach
        {
            get;
            set;
        }

        public List<TestCase> Cases
        {
            get;
            set;
        }
    }
}
