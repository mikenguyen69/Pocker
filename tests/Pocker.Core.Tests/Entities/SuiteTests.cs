using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pocker.Core.Entities;
using Pocker.Core.Exceptions;
using Pocker.Core.Helpers;

namespace Pocker.Core.Tests.Entities
{
    [TestClass]
    public class SuiteTests
    {
        [DataRow(GlobalConstants.SUITE_SPADES, 1000)]
        [DataRow(GlobalConstants.SUITE_CLUBS, 100)]
        [DataRow(GlobalConstants.SUITE_HEARTS, 10)]
        [DataRow(GlobalConstants.SUITE_DIAMONDS, 1)]
        [DataTestMethod]
        public void ShouldReturnValidPower(string type, int expectedPower)
        {
            // Arrange
            Suite suite = new Suite(type);

            // Act & Assert
            Assert.AreEqual(expectedPower, suite.Power);
        }

        [ExpectedException(typeof(InvalidSuiteException))]
        [TestMethod]
        public void ShouldThrowInvalidSuiteException()
        {
            // Arrange
            Suite suite = new Suite("NOT AVALIABLE SUITE");

            // Act
            int power = suite.Power;
        }
    }
}
