using System.Text;
using ProtractorBuilder.Protractor.Common;

namespace ProtractorBuilder.Protractor.Converter
{
    public static class CaseConverter
    {
        public static string ToProtractorCase(TestCase testCase)
        {
			var sb = new StringBuilder();

            sb.AppendCase(testCase);

			return sb.ToString();
        }
    }
}
