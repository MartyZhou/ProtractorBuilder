using System.Text;

namespace ProtractorBuilder.Protractor.Common
{
    public static class StringBuilderCaseExtension
    {
        public static void AppendCase(this StringBuilder sb, TestCase testCase)
        {
            sb.AppendFormat("it('{0}', async () => {{\n", testCase.Name);

            testCase.Steps.ForEach(sb.AppendStep);

            sb.Append("});\n\n");
        }
    }
}
