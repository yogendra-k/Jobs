using JobNimbus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JobNimbusTest
{
    [TestClass]
    public class BracketMatcherTest
    {
        [TestMethod]
        public void EmptyStringTest()
        {
            Boolean result = BracketMatcher.Match("");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InputStartsWithClosingBracketTest()
        {
            Boolean result = BracketMatcher.Match("}{}");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InputStartsWithOpeningAndClosingBracketTest()
        {
            Boolean result = BracketMatcher.Match("{}");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void BracketsNotMatchingTest()
        {
            Boolean result = BracketMatcher.Match("{{}");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ClosingBracketsMoreThanOpeningBracketsTest()
        {
            Boolean result = BracketMatcher.Match("{{}}}");

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void OnlyOpeningBracketsNoClosingBracketsTest()
        {
            Boolean result = BracketMatcher.Match("{{");

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void OnlyClosingBracketsNoOpeningBracketsTest()
        {
            Boolean result = BracketMatcher.Match("}}");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void MatchingBracketsWithinStringTest()
        {
            Boolean result = BracketMatcher.Match("The brown fox {jumps over { the lazy } dog }");

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void NonMatchingBracketsWithinStringTest()
        {
            Boolean result = BracketMatcher.Match("The brown fox {jumps over { the lazy } dog ");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ClosingBracketsMoreThanOpeningBracketsInStringTest()
        {
            Boolean result = BracketMatcher.Match("The brown fox jumps over { the lazy } dog} ");

            Assert.IsFalse(result);
        }


    }
}
