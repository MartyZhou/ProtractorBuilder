namespace ProtractorBuilder.Protractor.Common
{
    public class TestStep
    {
        public string Name
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public ActionSequence ActionSequence
        {
            get;
            set;
        }

        public Locator Locator
        {
            get;
            set;
        }

        public TestStep ResultFrom
        {
            get;
            set;
        }
    }
}
