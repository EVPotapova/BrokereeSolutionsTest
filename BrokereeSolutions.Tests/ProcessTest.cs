using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using BrokereeSolutions.Models;
using BrokereeSolutions.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrokereeSolutions.Tests
{
    [TestClass]
    public class ProcessTest
    {
        [TestMethod]
        public async Task TestBinaryToCsv()
        {
            Process process = new Process(@"C:\BSTest\Input",DocumentTypeEnum.Csv);
            await process.ProcessBinaryFiles();
        }

        [TestMethod]
        public async Task TestGetList()
        {
            Process process = new Process(@"C:\BSTest\Input", DocumentTypeEnum.Csv);

            await process.ProcessBinaryFiles();
            process.GetTasksStatuses();
            Thread.Sleep(1000);
            process.GetTasksStatuses();
            Console.ReadLine();
        }

        [TestMethod]
        public async Task GenerateSomeTestFiles()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(@"C:\BSTest\Input\Small", FileMode.OpenOrCreate)))
                for (int i = 0; i < 300000; i++)
                {
                    TradeRecord res = new TradeRecord
                    {
                        id = i,
                        account = i * -1,
                        volume=10.1,
                        comment="this is comment"
                    };

                    writer.Write(res.id);
                    writer.Write(res.account);
                    writer.Write(res.volume);
                    writer.Write(res.comment);
                }
        }
    }
}
