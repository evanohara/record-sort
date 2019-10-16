using RecordSortShared.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordSortConsoleApplication.Tests
{
    [TestFixture]
    class CJFilerParserTests
    {
        // Lol, don't judge me on this one. I stopped googling and just wanted to see.
        // if I could figure out a way to test the results given a valid file.  
        // Might be considered an integration test?
        [Test]
        public void ParseFile_GivenValidFile_ReturnRecordListWithElements()
        {
            // Assemble
            string fileContents = "Wilmerschmidt|John|Male|Perriwinkle|1984-11-11";
            byte[] buffer = Encoding.ASCII.GetBytes(fileContents);
            MemoryStream ms = new MemoryStream(buffer);
            StreamReader file = new StreamReader(ms);

            // Act
            IList<Record> result = CJFileParser.ParseFile(file);

            // Assert
            IList<Record> expected = new List<Record>() {
                new Record("Wilmerschmidt", "John", "Male", "Perriwinkle", DateTime.Parse("1984-11-11"))};
            Assert.AreEqual(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(result));
        }

        [Test]
        [TestCase("BettyDavisEyes")]
        [TestCase("Not|Enough|Properties")]
        public void ParseFile_GivenInvalidFile_ReturnNull(string fileContents)
        {
            // Assemble
            byte[] buffer = Encoding.ASCII.GetBytes(fileContents);
            MemoryStream ms = new MemoryStream(buffer);
            StreamReader file = new StreamReader(ms);

            // Act
            IList<Record> result = CJFileParser.ParseFile(file);

            // Assert
            Assert.AreEqual(result, null);
        }
    }
}
