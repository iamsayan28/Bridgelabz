using System.Text.RegularExpressions;

namespace Review2Testing
{
    public class Tests
    {
        private TokenExt<string> extractor;
        private string text;

        [SetUp]
        public void Setup()
        {
            text = "asb cASA BDcf ghs asb";
            extractor = new TokenExt<string>("Words", @"\b[a-z]+\b", match => match.Value);
        }

        [Test]
        public void ReturnsExpectedTokensInLifoOrder()
        {
            List<string> result = extractor.ApplyRules(text);

            List<string> expected = new List<string> { "ghs", "asb" };

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CountIsCorrect()
        {
            List<string> result = extractor.ApplyRules(text);

            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void ContainsRule()
        {
            Assert.That(extractor.GetRules().ContainsKey("Words"), Is.True);
        }

        [Test]
        public void AddsNewRuleToDictionary()
        {
            extractor.AddRule("Numbers", @"\d+", match => match.Value);

            Assert.That(extractor.GetRules().ContainsKey("Numbers"), Is.True);
        }

        [Test]
        public void RemovesRuleFromDictionary()
        {
            extractor.AddRule("Numbers", @"\d+", match => match.Value);
            extractor.RemoveRule("Numbers");

            Assert.That(extractor.GetRules().ContainsKey("Numbers"), Is.False);
        }
    }
}
