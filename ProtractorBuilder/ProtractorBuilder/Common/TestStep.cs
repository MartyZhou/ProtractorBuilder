namespace ProtractorBuilder.Protractor.Common
{
    public class TestStep : TestEntity
    {
        public string Value { get; set; }

        public ActionSequence ActionSequence { get; set; }

        public Locator Locator { get; set; }

        public string LastSuccessfulElement { get; set; }

        public string CurrentFailedElement { get; set; }

        public TestStep ResultFrom { get; set; }
    }
}
