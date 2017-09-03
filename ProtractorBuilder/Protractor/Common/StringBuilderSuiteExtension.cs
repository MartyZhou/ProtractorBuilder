using System.Text;

namespace ProtractorBuilder.Protractor.Common
{
    public static class StringBuilderSuiteExtension
    {
        public static void AppendSuite(this StringBuilder sb, TestSuite suite)
        {
            sb.AppendFormat("var regeneratorRuntime = require('regenerator-runtime');\n\ndescribe('{0}', () => {{\n", suite.Name);

            if (suite.BeforeAll != null && suite.BeforeAll.Count > 0)
            {
                sb.Append("beforeAll(async () => {\nbrowser.ignoreSynchronization = true;\n");
                suite.BeforeAll.ForEach(sb.AppendStep);
                sb.Append("});\n\n");
            }

            // TODO, append BeforeEach

            suite.Cases.ForEach(sb.AppendCase);

            // TODO, append AfterEach
            // TODO, append AfterAll

            sb.Append("});\n");
        }
    }
}
