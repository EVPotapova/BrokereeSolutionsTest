using System;
using System.Collections.Generic;
using System.Linq;
using BrokereeSolutions.Services.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrokereeSolutions.Tests
{
    [TestClass]
    public class ExtensionTests
    {
        [TestMethod]
        public void TestSplit()
        {
            List<int> testList = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10,11
            };

            var groups = testList.Split(2);

            Assert.AreEqual(groups.Count(),2);
        }

        [TestMethod]
        public void TestSplitLosses()
        {
            List<int> testList = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10,11
            };

            var groups = testList.Split(2).ToList();


            Assert.AreEqual(testList.Count, groups[0].Count() + groups[1].Count());
        }

        [TestMethod]
        public void TestSplitEmptyList()
        {
            List<int> testList = new List<int>();

            var groups = testList.Split(2);

            Assert.AreEqual(groups.Count(), 0);
        }
    }
}
