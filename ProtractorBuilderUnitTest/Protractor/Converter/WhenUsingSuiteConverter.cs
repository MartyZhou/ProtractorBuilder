using ProtractorBuilder.Protractor.Converter;
using Xunit;

namespace ProtractorBuilderUnitTest.Protractor.Converter
{
    public class WhenUsingSuiteConverter
    {
        [Fact]
        public void ToProtractorSuite_Convert()
        {
            var suite = MockData.MockSuite();

            var result = SuiteConverter.ToProtractorSuite(suite);

            Assert.Equal(@"var regeneratorRuntime = require('regenerator-runtime');

describe('Test Suite: Awesome describe', () => {
beforeAll(async () => {
browser.ignoreSynchronization = true;
await browser.get('http://localhost:3000');
});

it('Test Case: should execute the case', async () => {
await browser.actions().mouseMove({ x: 0, y: 0 }).perform();
let guid_without_hyphen_abcd_0001 = await element(by.className('awesome-class'));
let guid_without_hyphen_abcd_1234 = await guid_without_hyphen_abcd_0001.element(by.linkText('Test Link Text'));
await browser.actions().mouseMove(guid_without_hyphen_abcd_1234).perform();
expect(guid_without_hyphen_abcd_1234).toBe('TestText');
});

});
", result);
        }
    }
}
