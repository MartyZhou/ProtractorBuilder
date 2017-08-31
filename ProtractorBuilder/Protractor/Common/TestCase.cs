using System.Collections.Generic;

namespace ProtractorBuilder.Protractor.Common
{
    public class TestCase
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

        public List<TestStep> Steps
        {
            get;
            set;
        }
    }
}
