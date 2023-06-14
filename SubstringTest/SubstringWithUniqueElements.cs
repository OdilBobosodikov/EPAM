using EPAM;

namespace SubstringTest
{

    [TestClass]
    public class SubstringWithUniqueElements
    {
        #region All Types of chars
        [TestMethod]
        [TestCategory("All Types of chars")]
        [Description("Test not null values for substring with general elements")]
        [DataRow("abc1 23!@#", "23!@#")]
        [DataRow("qqwed12zx c!2", "qwed12zx")]
        [DataRow("abAAB123", "AB123")]
        [DataRow("123aAa123", "123aA")]
        [DataRow("aaaBBB222", "aB")]
        public void TestNotNullValuesForGeneralElements(string input, string expectedOutput)
        {
            Substring substr = new Substring();

            string[] words = substr.SplitString(input);
            string receivedOutput = substr.LongestSubstring(words);

            Assert.AreEqual(expectedOutput, receivedOutput);
        }

        [TestMethod]
        [TestCategory("All Types of chars")]
        [Description("Test null values for substring with general elements")]
        [DataRow(null)]
        [DataRow(new string[] { "" })]
        [DataRow(new string[] { " " })]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullValuesForGeneralElements(string[] nullString)
        {
            Substring substr = new Substring();
            substr.LongestSubstring(nullString);

            Assert.Fail("ArgumentNullException should have been thrown");
        }
        #endregion

        #region Letters

        [TestMethod]
        [TestCategory("Letters")]
        [Description("Test not null values for substring with letters")]
        [DataRow("abc1 23!@#", "abc")]
        [DataRow("qqwed12zx c!2", "qwed")]
        [DataRow("abACB123", "abACB")]
        [DataRow("123aAa123", "aA")]
        [DataRow("aaaBBB222", "aB")]
        [DataRow("qwe1rtyuiop", "rtyuiop")]
        [DataRow("12345", "")]
        [DataRow("!@#$%^", "")]
        public void TestNotNullValuesForLetters(string input, string expectedOutput)
        {
            Substring substr = new Substring();

            string[] words = substr.SplitString(input);
            string receivedOutput = substr.LongestSubstringWithLetters(words);


            Assert.AreEqual(expectedOutput, receivedOutput);
        }

        [TestMethod]
        [TestCategory("Letters")]
        [Description("Test null values for substring with letters")]
        [DataRow(null)]
        [DataRow(new string[] { "" })]
        [DataRow(new string[] { " " })]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullValuesForLettets(string[] nullString)
        {
            Substring substr = new Substring();
            substr.LongestSubstringWithLetters(nullString);

            Assert.Fail("ArgumentNullException should have been thrown");
        }
        #endregion

        #region Digits

        [TestMethod]
        [TestCategory("Digits")]
        [Description("Test not null values for substring with digits")]
        [DataRow("abc1 23!@#", "23")]
        [DataRow("qqwed12zx c!2", "12")]
        [DataRow("abAAB123", "123")]
        [DataRow("123aAa123", "123")]
        [DataRow("aaaBBB222", "2")]
        [DataRow("145a6789", "6789")]
        [DataRow("qwerty", "")]
        [DataRow("!@#$%^", "")]
        public void TestNotNullValuesForDigits(string input, string expectedOutput)
        {
            Substring substr = new Substring();

            string[] words = substr.SplitString(input);
            string receivedOutput = substr.LongestSubstringWithDigits(words);

            Assert.AreEqual(expectedOutput, receivedOutput);
        }

        [TestMethod]
        [TestCategory("Digits")]
        [Description("Test null values for substring with digits")]
        [DataRow(null)]
        [DataRow(new string[] { "" })]
        [DataRow(new string[] { " " })]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullValuesForDigits(string[] nullString)
        {
            Substring substr = new Substring();
            substr.LongestSubstringWithDigits(nullString);

            Assert.Fail("ArgumentNullException should have been thrown");
        }
        #endregion
    }
}