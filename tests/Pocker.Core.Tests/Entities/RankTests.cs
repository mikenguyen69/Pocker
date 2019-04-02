using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core.Entities;
using Poker.Core.Exceptions;
using Poker.Core.Helpers;

namespace Poker.Core.Tests.Entities
{
    [TestClass]
    public class RankTests
    {
        [DataRow(GlobalConstants.RANK_A, 14)]
        [DataRow(GlobalConstants.RANK_K, 13)]
        [DataRow(GlobalConstants.RANK_Q, 12)]
        [DataRow(GlobalConstants.RANK_J, 11)]
        [DataRow(GlobalConstants.RANK_10, 10)]
        [DataRow(GlobalConstants.RANK_9, 9)]
        [DataRow(GlobalConstants.RANK_8, 8)]
        [DataRow(GlobalConstants.RANK_7, 7)]
        [DataRow(GlobalConstants.RANK_6, 6)]
        [DataRow(GlobalConstants.RANK_5, 5)]
        [DataRow(GlobalConstants.RANK_4, 4)]
        [DataRow(GlobalConstants.RANK_3, 3)]
        [DataRow(GlobalConstants.RANK_2, 2)]
        [DataTestMethod]
        public void ShouldReturnValidPowers(string type, int expectedPower)
        {
            // Arrange 
            Rank rank = new Rank(type);

            // Act & Assert
            Assert.AreEqual(expectedPower, rank.Power);
        }

        [ExpectedException(typeof(InvalidRankException))]
        [TestMethod]
        public void ShouldThrowInvalidRankException()
        {
            // Arrange 
            Rank rank = new Rank("NOT AVAILABLE RANK");

            // Act
            int power = rank.Power;
        }
    }
}
