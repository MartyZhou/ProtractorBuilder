using System.Collections.Generic;

namespace ProtractorBuilder.Protractor.Common
{
    public class TestSuit
    {
        public string Name
        {
            get;
            set;
        }

        public bool Enabled
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
