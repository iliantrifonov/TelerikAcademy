namespace _4._2.TestFindLongestSequence
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _4.FindLongestSubsequence;

    [TestClass]
    public class LongestSequenceTest
    {
        [TestMethod]
        public void TestWithArray()
        {
            int[] numbers = { 3, 3, 3, 4, 4, 1, 4 };
            var result = Program.GetLongestSequence(numbers);
            Assert.AreEqual(3, result.Count());
            foreach (var number in result)
            {
                Assert.AreEqual(3, number); 
            }
        }
    }
}
