using NUnit.Framework;
using SubtitleSplitter;
namespace SubtitleSplitter.Tests
{
    [TestFixture]
    public class SubtitleParserTests
    {
        [Test]
        public void ParseStringWithLessThan25Chars()
        {
            string SAMPLE_TEXT = "Please write a program";
            ISubtitleParser subTitleParser = new SubtitleParser();
           var expectResult= subTitleParser.Parse(SAMPLE_TEXT);
            Assert.That(expectResult.Count.Equals(1));
        }

        [Test]
        public void BreakSentenceWithIn5Chars()
        {
            string SAMPLE_TEXT = "Please write a progr,am 12";
            ISubtitleParser subTitleParser = new SubtitleParser();
            var expectResult = subTitleParser.Parse(SAMPLE_TEXT);
            Assert.That(expectResult[1].Length.Equals(5));
        }
        [Test]
        public void RemoveRedundentWhiteSpaces()
        {
            string SAMPLE_TEXT = "Please   write  a program";
            ISubtitleParser subTitleParser = new SubtitleParser();
            var expectResult = subTitleParser.Parse(SAMPLE_TEXT);
            Assert.AreNotEqual(expectResult, SAMPLE_TEXT);
        }
    }
}