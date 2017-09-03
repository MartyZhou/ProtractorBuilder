using System.Text;
using ProtractorBuilder.Protractor.Common;

namespace ProtractorBuilder.Protractor.Converter
{
    public static class StepConverter
    {
        public static string ToProtractorStep(TestStep step)
        {
            var sb = new StringBuilder();

            sb.AppendStep(step);

            return sb.ToString();
        }
    }
}