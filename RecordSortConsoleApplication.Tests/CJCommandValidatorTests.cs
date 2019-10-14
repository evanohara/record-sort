using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftJackRecordSortConsoleApplication.Tests
{
    [TestFixture]
    class CJCommandValidatorTests
    {
        [Test]
        [TestCase("NotSingleCharacter")]
        [TestCase("")]
        [TestCase("F")]
        public void IsValidCommand_GivenInvalidInput_ReturnsFalse(string input)
        {
            // No Assembly Required

            // Act
            bool result = CJCommandValidator.IsValidCommand(input);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("L")]
        [TestCase("x")] // Lower Case
        public void IsValidCommand_GivenValidInput_ReturnsTrue(string input)
        {
            // No Assembly Required

            // Act
            bool result = CJCommandValidator.IsValidCommand(input);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
