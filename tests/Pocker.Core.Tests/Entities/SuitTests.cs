using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pocker.Core.Entities;
using Pocker.Core.Exceptions;
using Pocker.Core.Helpers;

namespace Pocker.Core.Tests.Entities
{
    [TestClass]
    public class SuitTests
    {
        [DataRow(GlobalConstants.SUIT_SPADES, 1000)]
        [DataRow(GlobalConstants.SUIT_CLUBS, 100)]
        [DataRow(GlobalConstants.SUIT_HEARTS, 10)]
        [DataRow(GlobalConstants.SUIT_DIAMONDS, 1)]
        [DataTestMethod]
        public void ShouldReturnValidPower(string type, int expectedPower)
        {
            // Arrange
            Suit suite = new Suit(type);

            // Act & Assert
            Assert.AreEqual(expectedPower, suite.Power);
        }

        [ExpectedException(typeof(InvalidSuitException))]
        [TestMethod]
        public void ShouldThrowInvalidSuiteException()
        {
            // Arrange
            Suit suite = new Suit("NOT AVALIABLE SUITE");

            // Act
            int power = suite.Power;
        }
    }
}
