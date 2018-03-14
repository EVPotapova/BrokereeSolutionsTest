using System;
using System.IO;
using System.Threading.Tasks;
using BrokereeSolutions.Models;
using BrokereeSolutions.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrokereeSolutions.Tests
{
    [TestClass]
    public class ProcessTests
    {
        [TestMethod]
        public async Task TestBinaryToCsv()
        {
            
        }

        [TestMethod]
        public void GetNotExistsTaskStatusTest()
        {
            Process process = new Process(Path.Combine("TestItems"), DocumentTypeEnum.Binary, DocumentTypeEnum.Csv);

            var status = process.GetTaskStatus(666);

            Assert.AreEqual("Task is not found.", status, true);
        }

        [TestMethod]
        public async Task TestGetList()
        {

        }

        //[TestMethod]
        //public void GenerateSomeTestFiles()
        //{
        //    using (BinaryWriter writer = new BinaryWriter(File.Open(@"testFile", FileMode.OpenOrCreate)))
        //        for (int i = 0; i < 300; i++)
        //        {
        //            TradeRecord res = new TradeRecord
        //            {
        //                id = i,
        //                account = i * -1,
        //                volume = 10.1,
        //                comment = "this is comment"
        //            };

        //            writer.Write(res.id);
        //            writer.Write(res.account);
        //            writer.Write(res.volume);
        //            writer.Write(res.comment);
        //        }
        //}
    }
}
