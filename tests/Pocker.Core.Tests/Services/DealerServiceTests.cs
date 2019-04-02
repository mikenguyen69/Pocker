using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pocker.Core.Entities;
using Pocker.Core.Helpers;
using Pocker.Core.Interfaces;
using Pocker.Core.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocker.Core.Tests.Services
{
    [TestClass]
    public class DealerServiceTests
    {
        private IDealerService _dealer;
        private Deck deck;
        public DealerServiceTests()
        {
            DependencyInjector injector = new DependencyInjector();
            _dealer = injector.ResolveService<IDealerService>();
            deck = new Deck();
        }

        [TestMethod]
        public void Shuffle_ShouldMakeTheCardSequenceDifferent()
        {
            // Arrange 
            _dealer.Shuffle(deck, 1);
            var before = Clone(deck.Cards);
            _dealer.Shuffle(deck, 1);
            var after = Clone(deck.Cards);

            // Act && Assert
            Assert.IsTrue(HasDifferentSequences(before, after));
        }

        [TestMethod]
        public void DealCards_ShouldReturnVisibleCardsToPlayerHand()
        {
            // Arrange 
            PlayerHand playerHand = new PlayerHand(new Player("Mike"), 2);

            // Act
            _dealer.DealCards(deck, playerHand);

            // Assert
            Assert.AreEqual(2, playerHand.Cards.Count(x => x.Visible));
            Assert.AreEqual(50, deck.Cards.Count(x => !x.Visible));
            Assert.AreEqual(2, deck.Cards.Count(x => x.Visible));
        }


        [TestMethod]
        public void CalculateHandRank_ShouldReturn5ForStraightFlush()
        {
            // Arrange 
            var hand = new PlayerHand(new Player("Mike"), 2)
            {
                Cards = new List<Card>() {
                new Card(GlobalConstants.SUIT_DIAMONDS, GlobalConstants.RANK_K),
                new Card(GlobalConstants.SUIT_DIAMONDS, GlobalConstants.RANK_A)}
            };

            // Act 
            _dealer.CalculateHandRank(hand);

            // Assert
            Assert.AreEqual(5, hand.HandRankPower);
        }

        [TestMethod]
        public void CalculateHandRank_ShouldReturn4ForFlush()
        {
            // Arrange 
            var hand = new PlayerHand(new Player("Mike"), 2)
            {
                Cards = new List<Card>() {
                new Card(GlobalConstants.SUIT_DIAMONDS, GlobalConstants.RANK_K),
                new Card(GlobalConstants.SUIT_DIAMONDS, GlobalConstants.RANK_10) }
            };

            // Act 
            _dealer.CalculateHandRank(hand);

            // Assert
            Assert.AreEqual(4, hand.HandRankPower);
        }

        [TestMethod]
        public void CalculateHandRank_ShouldReturn3ForStraight()
        {
            // Arrange 
            var hand = new PlayerHand(new Player("Mike"), 2)
            {
                Cards = new List<Card>() {
                new Card(GlobalConstants.SUIT_SPADES, GlobalConstants.RANK_K),
                new Card(GlobalConstants.SUIT_DIAMONDS, GlobalConstants.RANK_A) }
            };

            // Act 
            _dealer.CalculateHandRank(hand);

            // Assert
            Assert.AreEqual(3, hand.HandRankPower);
        }

        [TestMethod]
        public void CalculateHandRank_ShouldReturn2ForPair()
        {
            // Arrange 
            var hand = new PlayerHand(new Player("Mike"), 2)
            {
                Cards = new List<Card>() {
                    new Card(GlobalConstants.SUIT_DIAMONDS, GlobalConstants.RANK_A),
                    new Card(GlobalConstants.SUIT_HEARTS, GlobalConstants.RANK_A) }
            };

            // Act 
            _dealer.CalculateHandRank(hand);

            // Assert
            Assert.AreEqual(2, hand.HandRankPower);
        }

        [TestMethod]
        public void CalculateHandRank_ShouldReturn1FOrOnlyHighCard()
        {
            // Arrange 
            var hand = new PlayerHand(new Player("Mike"), 2)
            {
                Cards = new List<Card>() {
                    new Card(GlobalConstants.SUIT_DIAMONDS, GlobalConstants.RANK_K),
                new Card(GlobalConstants.SUIT_SPADES, GlobalConstants.RANK_2) }
            };

            // Act 
            _dealer.CalculateHandRank(hand);

            // Assert
            Assert.AreEqual(1, hand.HandRankPower);
        }

        #region Helpers
        public bool HasDifferentSequences(IList<Card> before, IList<Card> after)
        {
            int n = before.Count;
            int i = 0;

            while (i++ < n)
            {
                if (!before[i].Equals(after[i]))
                    return true;
            }

            return false;
        }

        public IList<Card> Clone(IList<Card> cards)
        {
            var newCards = new List<Card>();

            foreach (var card in cards)
            {
                newCards.Add(card);
            }

            return newCards;
        }

        #endregion
    }
}
