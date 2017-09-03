using System.Text;
using ProtractorBuilder.Protractor.Common;

namespace ProtractorBuilder.Protractor.Converter
{
    public static class SuiteConverter
    {
        public static string ToProtractorSuite(TestSuite suite){
            var sb = new StringBuilder();
            sb.AppendSuite(suite);
            return sb.ToString();
        }
    }
}
