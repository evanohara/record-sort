using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordSortConsoleApplication.Tests
{
    [TestFixture]
    public class CJStringManipulatorTests
    {
        // Designing this test caught that I had an off by 1.. that makes me happy.
        [Test]
        [TestCase("LessThan")]
        [TestCase("MoreThanTwelve")]
        public void GetStringOfExactLength_WhenCalled_GetsStringOfRequestedLength(string str)
        {
            // Assemble

            // Act
            var result = CJStringManipulator.GetStringOfExactLength(12, str).Length;

            // Assert
            Assert.AreEqual(12, result);
        }
    }
}
