using System.Collections.Generic;
using ProtractorBuilder.Protractor.Common;

namespace ProtractorBuilderUnitTest.Protractor.Converter
{
    public static class MockData
    {
        public static TestSuite MockSuite()
        {
            return new TestSuite()
            {
                Name = "Test Suite: Awesome describe",
                Enabled = true,

                //BeforeAll = new List<TestStep>
                //{
                //    MockLoadUrlStep()
                //},
                Cases = new List<TestCase>
                {
                    MockCase()
                }
            };
        }

        public static TestCase MockCase()
        {
            var testCase = new TestCase()
            {
                Name = "Test Case: should execute the case",
                Enabled = true,

                Steps = new List<TestStep>()
            };

            var moveLeftTopStep = MockMoveLeftTopStep();
            var byClassStep = MockByClassNameStep();
            var byLinkTextStep = MockByLinkTextStep();
            byLinkTextStep.ResultFrom = byClassStep;
            var moveToElementStep = MockMoveLeftTopStep();
            moveToElementStep.ResultFrom = byLinkTextStep;
            var toBeStep = MockToBeStep();
            toBeStep.ResultFrom = byLinkTextStep;

            testCase.Steps.Add(moveLeftTopStep);
            testCase.Steps.Add(byClassStep);
            testCase.Steps.Add(byLinkTextStep);
            testCase.Steps.Add(moveToElementStep);
            testCase.Steps.Add(toBeStep);

            return testCase;
        }

        public static TestStep MockLoadUrlStep()
        {
            return new TestStep()
            {
                Id = "guid_load_url",
                Name = "Load URL",
                ActionSequence = ActionSequence.loadUrl,
                Value = "http://localhost:3000"
            };
        }

        public static TestStep MockMoveLeftTopStep()
        {
            return new TestStep()
            {
                Name = "Test Move Step",
                ActionSequence = ActionSequence.mouseMove,
                Id = "guid_without_hyphen_abcd_move",
                Value = @"{ x: 0, y: 0 }"
            };
        }

        public static TestStep MockClickStep()
        {
            var step = new TestStep()
            {
                Name = "Test Click Step",
                ActionSequence = ActionSequence.click,
                Id = "guid_without_hyphen_abcd_click"
            };
            return step;
        }

        public static TestStep MockGetTextStep()
        {
            return new TestStep()
            {
                Name = "Test GetText Step",
                ActionSequence = ActionSequence.getText,
                Id = "guid_without_hyphen_abcd_getText"
            };
        }

        public static TestStep MockToBeStep()
        {
            return new TestStep()
            {
                Name = "Test ToBe Step",
                ActionSequence = ActionSequence.expect,
                Id = "guid_without_hyphen_abcd_tobe",
                Value = @"toBe('TestText')"
            };
        }

        public static TestStep MockByLinkTextStep()
        {
            return new TestStep()
            {
                Name = "Test ByLinkText Step",
                ActionSequence = ActionSequence.locateElement,
                Id = "guid_without_hyphen_abcd_1234",
                Locator = Locator.linkText,
                Value = "Test Link Text"
            };
        }

        public static TestStep MockByClassNameStep()
        {
            return new TestStep()
            {
                Name = "Test ByClassName Step",
                ActionSequence = ActionSequence.locateElement,
                Id = "guid_without_hyphen_abcd_0001",
                Locator = Locator.className,
                Value = "awesome-class"
            };
        }
    }
}
