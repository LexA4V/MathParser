using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MathParser.Expressions;

namespace MathParser.Tests
{
    [TestClass]
    public class TestParse
    {
        [TestMethod]
        public void TestParse1()
        {
            string source = "1 2* (5 +3 -6 /7 +9 ) ";
            Expression tree = Parse.parse(source);

            Assert.AreEqual(tree.Evaluate().Value, 12 * (5 + 3 - 6.0 / 7 + 9));
        }

        [TestMethod]
        public void TestParse2()
        {
            string source = "5*2";
            Expression tree = Parse.parse(source);

            Assert.AreEqual(tree.Evaluate().Value, 10);
        }
    }
}
