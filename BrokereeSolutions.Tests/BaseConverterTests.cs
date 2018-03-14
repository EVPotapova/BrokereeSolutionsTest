using BrokereeSolutions.Models;
using BrokereeSolutions.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace BrokereeSolutions.Tests
{
    [TestClass]
    public class BaseConverterTests
    {
        [TestMethod]
        public void BinaryToCsvWriteTest()
        {
            BaseConverter converter = new BinaryConverter(Path.Combine("TestItems", "testFile"), DocumentTypeEnum.Csv);
            converter.ReadAndWrite();
            //Не ожидается исключение
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotExistsBinaryToCsvWriteTest()
        {
            BaseConverter converter = new BinaryConverter(String.Empty, DocumentTypeEnum.Csv);
            converter.ReadAndWrite();
        }
    }
}
