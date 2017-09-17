using System;
using System.Text;

namespace ProtractorBuilder.Protractor.Common
{
    public static class StringBuilderStepExtension
    {
        public static void AppendStep(this StringBuilder sb, TestStep step)
        {
            switch (step.ActionSequence)
            {
                case ActionSequence.locateElement:
                    sb.AppendLocateElement(step);
                    break;
                case ActionSequence.click:
                    sb.AppendClick(step);
                    break;
                case ActionSequence.mouseMove:
                    sb.AppendMove(step);
                    break;
                case ActionSequence.getText:
                    sb.AppendGetText(step);
                    break;
                case ActionSequence.expect:
                    sb.AppendExpect(step);
                    break;
                case ActionSequence.loadUrl:
                    sb.AppendLoadUrl(step);
                    break;
                case ActionSequence.wait:
                    sb.AppendWaitText(step);
                    break;
                case ActionSequence.sendKeys:
                    sb.AppendSendKeys(step);
                    break;
                default:
                    break;
            }
        }

        public static void AppendExpect(this StringBuilder sb, TestStep step)
        {
            if (step.ResultFrom != null)
            {
                sb.AppendFormat("expect({0}).{1};\n", step.ResultFrom.Id, step.Value);
            }
            else
            {
                sb.AppendLine("// TODO, fail this case.");
            }
        }

        public static void AppendWaitText(this StringBuilder sb, TestStep step)
        {
            try
            {
                sb.AppendFormat("await browser.sleep({0});\n", Convert.ToInt32(step.Value) * 1000);
            }
            catch (Exception ex)
            {
                // TODO handle exception.
            }
        }

        public static void AppendGetText(this StringBuilder sb, TestStep step)
        {
            if (step.ResultFrom != null)
            {
                sb.AppendFormat("let {0} = await {1}.getText();\n", step.Id, step.ResultFrom.Id);
            }
            else
            {
                sb.AppendLine("// TODO, fail this case.");
            }
        }

        public static void AppendLocateElement(this StringBuilder sb, TestStep step)
        {
            sb.Append(GetElementStep(step));
        }

        public static void AppendClick(this StringBuilder sb, TestStep step)
        {
            if (step.ResultFrom != null)
            {
                sb.AppendFormat("await {0}.click();\n", step.ResultFrom.Id);
            }
            else
            {
                sb.AppendLine("// TODO, fail this case.");
            }
        }

        public static void AppendMove(this StringBuilder sb, TestStep step)
        {
            if (step.ResultFrom != null)
            {
                sb.Append(GetMouseMoveStep(step.ResultFrom.Id));
            }
            else if (step.Value != null)
            {
                sb.Append(GetMouseMoveStep(step.Value));
            }
            else
            {
                sb.AppendLine("// TODO, fail this case.");
            }
        }

		public static void AppendSendKeys(this StringBuilder sb, TestStep step)
		{
			if (step.ResultFrom != null)
			{
                sb.AppendFormat("await {0}.sendKeys('{1}');\n", step.ResultFrom.Id, step.Value);
			}
			else
			{
				sb.AppendLine("// TODO, fail this case.");
			}
		}

        static void AppendLoadUrl(this StringBuilder sb, TestStep step)
        {
            sb.AppendFormat("await browser.get('{0}');\n", step.Value);
        }

        static string GetMouseMoveStep(string target)
        {
            return string.Format("await browser.actions().mouseMove({0}).perform();\n", target);
        }

        static string GetElementStep(TestStep step)
        {
            if (step.ResultFrom == null)
            {
                return string.Format("let {0} = await element(by.{1}('{2}'));\n",
                                     step.Id,
                                      step.Locator.ToString(),
                                      step.Value);
            }
            else
            {
                return GetElementStep(step, step.ResultFrom.Id);
            }
        }

        static string GetElementStep(TestStep step, string scope)
        {
            return string.Format("let {0} = await {1}.element(by.{2}('{3}'));\n",
                                 step.Id,
                                 scope,
                                 step.Locator.ToString(),
                                 step.Value);
        }
    }
}
