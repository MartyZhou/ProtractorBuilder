using ProtractorBuilder.Protractor.Converter;
using Xunit;

namespace ProtractorBuilderUnitTest.Protractor.Converter
{
    public class WhenUsingCaseConverter
    {
        [Fact]
        public void ToProtractorCase_Convert()
        {
            var testCase = MockData.MockCase();

            var result = CaseConverter.ToProtractorCase(testCase);

            Assert.Equal(@"it('Test Case: should execute the case', async () => {
await browser.actions().mouseMove({ x: 0, y: 0 }).perform();
let guid_without_hyphen_abcd_0001 = await element(by.className('awesome-class'));
let guid_without_hyphen_abcd_1234 = await guid_without_hyphen_abcd_0001.element(by.linkText('Test Link Text'));
await browser.actions().mouseMove(guid_without_hyphen_abcd_1234).perform();
expect(guid_without_hyphen_abcd_1234).toBe('TestText');
});
", result);
        }
    }
}
