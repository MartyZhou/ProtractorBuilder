using System.Linq;
using System.Text;

namespace ProtractorBuilder.Protractor.Common
{
    public static class StringBuilderSuiteExtension
    {
        public static void AppendSuite(this StringBuilder sb, TestSuite suite)
        {
            sb.AppendFormat("var regeneratorRuntime = require('regenerator-runtime');\n\ndescribe('{0}', () => {{\n", suite.Name);

            sb.Append("beforeAll(async () => {\nbrowser.ignoreSynchronization = true;\n");
            // TODO, append BeforeAll
            sb.Append("});\n\n");

            // TODO, append BeforeEach

            var cases = suite.Cases.OrderBy(c => c.Order).ToList();
            cases.ForEach(sb.AppendCase);
            //suite.Cases.ForEach(sb.AppendCase);

            // TODO, append AfterEach
            // TODO, append AfterAll

            sb.Append("});\n");
        }
    }
}
