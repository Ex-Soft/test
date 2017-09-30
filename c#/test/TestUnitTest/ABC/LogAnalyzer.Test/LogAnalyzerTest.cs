using System;
using NUnit.Framework;

namespace LogAnalyzer.Test
{
    [TestFixture]
    public class LogAnalyzerTest
    {
        private LogAnalyzer m_analyzer = null;

        private static LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }

        [SetUp]
        public void Setup()
        {
            m_analyzer = new LogAnalyzer();
        }

        [Test]
        public void IsValidFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");

            Assert.False(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionLowercase_ReturnsTrue()
        {
            bool result = m_analyzer.IsValidLogFileName("filewithgoodextension.slf");

            Assert.True(result);
        }

        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnsTrue()
        {
            bool result = m_analyzer.IsValidLogFileName("filewithgoodextension.SLF");

            Assert.True(result);
        }

        [TestCase("filewithgoodextension.SLF")]
        [TestCase("filewithgoodextension.slf")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string file)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName(file);

            Assert.True(result);
        }

        [TestCase("filewithgoodextension.SLF", true)]
        [TestCase("filewithgoodextension.slf", true)]
        [TestCase("filewithbadextension.foo", false)]
        public void IsValidLogFileName_VariousExtensions_ChecksThem(string file, bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void IsValidFileName_EmptyFileName_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => m_analyzer.IsValidLogFileName(string.Empty));
            Assert.That(() => m_analyzer.IsValidLogFileName(string.Empty), Throws.ArgumentException);

            var exception = Assert.Catch<ArgumentException>(() => m_analyzer.IsValidLogFileName(string.Empty));
            StringAssert.Contains("No filename provided!", exception.Message);
        }

        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
        {
            LogAnalyzer analyzer = MakeAnalyzer();

            analyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected, analyzer.WasLastFileNameValid);
        }

        [TearDown]
        public void TearDown()
        {
            m_analyzer = null;
        }
    }
}
