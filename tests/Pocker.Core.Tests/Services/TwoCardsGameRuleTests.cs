using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pocker.Core.Entities;
using Pocker.Core.Exceptions;
using Pocker.Core.Helpers;
using Pocker.Core.Interfaces;
using Pocker.Core.Tests.Helpers;
using System.Collections.Generic;

namespace Pocker.Core.Tests.Services
{
    [TestClass]
    public class TwoCardsGameRuleTests
    {
        private IGameRule _gameRule;
        public TwoCardsGameRuleTests()
        {
            DependencyInjector injector = new DependencyInjector();
            _gameRule = injector.ResolveService<IGameRule>();
        }
    
        [ExpectedException(typeof(InvalidNumberOfCardException))]
        [TestMethod]
        public void IsStraightFlush_ShouldInvalidNumberOfCardException()
        {
            // Arrange 
            var cards = new List<Card>();

            // Act
            _gameRule.IsStraightFlush(cards);
        }

        [DataRow(GlobalConstants.SUIT_SPADES)]
        [DataRow(GlobalConstants.SUIT_CLUBS)]
        [DataRow(GlobalConstants.SUIT_HEARTS)]
        [DataRow(GlobalConstants.SUIT_DIAMONDS)]
        [DataTestMethod]
        public void IsStraightFlush_ShouldReturnTrue(string suit)
        {
            // Arrange 
            var cards = new List<Card>() {
                new Card(suit, GlobalConstants.RANK_10),
                new Card(suit, GlobalConstants.RANK_J)
            };

            // Act & Assert
            Assert.IsTrue(_gameRule.IsStraightFlush(cards));
        }

        [ExpectedException(typeof(InvalidNumberOfCardException))]
        [TestMethod]
        public void IsFlush_ShouldInvalidNumberOfCardException()
        {
            // Arrange 
            var cards = new List<Card>();

            // Act
            _gameRule.IsFlush(cards);
        }

        [DataRow(GlobalConstants.SUIT_SPADES)]
        [DataRow(GlobalConstants.SUIT_CLUBS)]
        [DataRow(GlobalConstants.SUIT_HEARTS)]
        [DataRow(GlobalConstants.SUIT_DIAMONDS)]
        [DataTestMethod]
        public void IsPlush_ShouldReturnTrue(string suit)
        {
            // Arrange 
            var cards = new List<Card>() {
                new Card(suit, GlobalConstants.RANK_J),
                new Card(suit, GlobalConstants.RANK_A)
            };

            // Act & Assert
            Assert.IsTrue(_gameRule.IsFlush(cards));
        }

        [ExpectedException(typeof(InvalidNumberOfCardException))]
        [TestMethod]
        public void IsStraight_ShouldInvalidNumberOfCardException()
        {
            // Arrange 
            var cards = new List<Card>();

            // Act
            _gameRule.IsStraight(cards);
        }

        [DataRow(GlobalConstants.SUIT_SPADES, GlobalConstants.SUIT_HEARTS)]
        [DataRow(GlobalConstants.SUIT_CLUBS, GlobalConstants.SUIT_HEARTS)]
        [DataRow(GlobalConstants.SUIT_HEARTS, GlobalConstants.SUIT_SPADES)]
        [DataRow(GlobalConstants.SUIT_DIAMONDS, GlobalConstants.SUIT_HEARTS)]
        [DataTestMethod]
        public void IsStraight_ShouldReturnTrue(string suit1, string suit2)
        {
            // Arrange 
            var cards = new List<Card>() {
                new Card(suit1, GlobalConstants.RANK_K),
                new Card(suit2, GlobalConstants.RANK_A)
            };

            // Act & Assert
            Assert.IsTrue(_gameRule.IsStraight(cards));
        }


        [ExpectedException(typeof(InvalidNumberOfCardException))]
        [TestMethod]
        public void HasPair_ShouldInvalidNumberOfCardException()
        {
            // Arrange 
            var cards = new List<Card>();

            // Act
            _gameRule.HasPair(cards);
        }

        [DataRow(GlobalConstants.RANK_A)]
        [DataRow(GlobalConstants.RANK_K)]
        [DataRow(GlobalConstants.RANK_Q)]
        [DataRow(GlobalConstants.RANK_J)]
        [DataRow(GlobalConstants.RANK_10)]
        [DataRow(GlobalConstants.RANK_9)]
        [DataRow(GlobalConstants.RANK_8)]
        [DataRow(GlobalConstants.RANK_7)]
        [DataRow(GlobalConstants.RANK_6)]
        [DataRow(GlobalConstants.RANK_5)]
        [DataRow(GlobalConstants.RANK_4)]
        [DataRow(GlobalConstants.RANK_3)]
        [DataRow(GlobalConstants.RANK_2)]
        [DataTestMethod]
        public void HasPair_ShouldReturnTrue(string rank)
        {
            // Arrange 
            var cards = new List<Card>() {
                new Card(GlobalConstants.SUIT_HEARTS, rank),
                new Card(GlobalConstants.SUIT_SPADES, rank)
            };

            // Act & Assert
            Assert.IsTrue(_gameRule.HasPair(cards));
        }
        
    }
}
