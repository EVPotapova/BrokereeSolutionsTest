using BrokereeSolutions.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokereeSolutions.Tests
{
    [TestClass]
    public class DocumentTypeTests
    {
        [TestMethod]
        public void WriteToCsvTest()
        {
            string path = "someTest.csv";
            CsvDocumentType dt = new CsvDocumentType(path);
            TradeRecord record = new TradeRecord();
            dt.WriteRecord(record);
            
            //Не ожидается исключения
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WriteToNotExistsCsvTest()
        {
            string path = "";
            CsvDocumentType dt = new CsvDocumentType(path);
            TradeRecord record = new TradeRecord();
            dt.WriteRecord(record);
            
        }
    }
}
