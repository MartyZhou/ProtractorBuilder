using System.Collections.Generic;

namespace ProtractorBuilder.Protractor.Common
{
    public class TestModule
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

        public List<TestSuit> Suits
        {
            get;
            set;
        }
    }
}
