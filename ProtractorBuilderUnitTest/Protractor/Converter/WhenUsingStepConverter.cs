using ProtractorBuilder.Protractor.Converter;
using Xunit;

namespace ProtractorBuilderUnitTest.Protractor.Converter
{
    public class WhenUsingStepConverter
    {
        [Fact]
        public void ToProtractorStep_ClickStep()
        {
            var byLinkTextStep = MockData.MockByLinkTextStep();
            var clickStep = MockData.MockClickStep();
            clickStep.ResultFrom = byLinkTextStep;

            var step1Result = StepConverter.ToProtractorStep((byLinkTextStep));
            var result = StepConverter.ToProtractorStep(clickStep);

            Assert.Equal("let guid_without_hyphen_abcd_1234 = await element(by.linkText('Test Link Text'));\n", step1Result);

            Assert.Equal("await guid_without_hyphen_abcd_1234.click();\n", result);
        }

        [Fact]
        public void ToProtractorStep_ClickStep_WithScope()
        {
            var step1 = MockData.MockByClassNameStep();
            var byLinkTextStep = MockData.MockByLinkTextStep();
            byLinkTextStep.ResultFrom = step1;
            var clickStep = MockData.MockClickStep();
            clickStep.ResultFrom = byLinkTextStep;

            var step1Result = StepConverter.ToProtractorStep(step1);
            var step2Result = StepConverter.ToProtractorStep(byLinkTextStep);
            var result = StepConverter.ToProtractorStep(clickStep);

            Assert.Equal("let guid_without_hyphen_abcd_0001 = await element(by.className('awesome-class'));\n", step1Result);

            Assert.Equal("let guid_without_hyphen_abcd_1234 = await guid_without_hyphen_abcd_0001.element(by.linkText('Test Link Text'));\n", step2Result);

            Assert.Equal("await guid_without_hyphen_abcd_1234.click();\n", result);
        }

        [Fact]
        public void ToProtractorStep_MoveTo_Left_Top()
        {
            var moveStep = MockData.MockMoveLeftTopStep();

            var result = StepConverter.ToProtractorStep((moveStep));

            Assert.Equal("await browser.actions().mouseMove({ x: 0, y: 0 }).perform();\n", result);
        }

        [Fact]
        public void ToProtractorStep_MoveTo_Element()
        {
            var byLinkTextStep = MockData.MockByLinkTextStep();
            var moveStep = MockData.MockMoveLeftTopStep();
            moveStep.ResultFrom = byLinkTextStep;

            var result = StepConverter.ToProtractorStep((moveStep));

            Assert.Equal("await browser.actions().mouseMove(guid_without_hyphen_abcd_1234).perform();\n", result);
        }

		[Fact]
		public void ToProtractorStep_GetText()
		{
			var byLinkTextStep = MockData.MockByLinkTextStep();
            var step = MockData.MockGetTextStep();
			step.ResultFrom = byLinkTextStep;

			var result = StepConverter.ToProtractorStep((step));

			Assert.Equal("let guid_without_hyphen_abcd_getText = await guid_without_hyphen_abcd_1234.getText();\n", result);
		}

		[Fact]
		public void ToProtractorStep_Expect_ToBe()
		{
			var byLinkTextStep = MockData.MockByLinkTextStep();
			var step = MockData.MockToBeStep();
			step.ResultFrom = byLinkTextStep;

			var result = StepConverter.ToProtractorStep((step));

			Assert.Equal("expect(guid_without_hyphen_abcd_1234).toBe('TestText');\n", result);
		}
    }
}
