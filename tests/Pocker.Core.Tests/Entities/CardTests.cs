using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core.Entities;
using Poker.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Core.Tests.Entities
{
    [TestClass]
    public class CardTests
    {
        [DataRow(GlobalConstants.SUIT_SPADES, GlobalConstants.SUIT_CLUBS)]
        [DataRow(GlobalConstants.SUIT_CLUBS, GlobalConstants.SUIT_HEARTS)]
        [DataRow(GlobalConstants.SUIT_HEARTS, GlobalConstants.SUIT_DIAMONDS)]
        [DataTestMethod]
        public void DifferentSuit_LowestRankOfHigherSuiteIsMorePowerThanHighestRankofLowerSuite(string highSuite, string lowSuite)
        {
            // Arrange 
            Card highCard = new Card(highSuite, GlobalConstants.RANK_2);
            Card lowCard = new Card(lowSuite, GlobalConstants.RANK_A);

            // Act
            bool stronger = highCard.Power > lowCard.Power;

            // Assert
            Assert.IsTrue(stronger);
        }

        [DataRow(GlobalConstants.SUIT_SPADES)]
        [DataRow(GlobalConstants.SUIT_CLUBS)]
        [DataRow(GlobalConstants.SUIT_HEARTS)]
        [DataRow(GlobalConstants.SUIT_DIAMONDS)]
        [DataTestMethod]
        public void SameSuit_HigherRankIsMorePowerful(string suite)
        {
            // Arrange 
            IList<Card> cards = new List<Card>();

            foreach(string rank in GlobalConstants.RANK_LIST)
            {
                var card = new Card(suite, rank);
                cards.Add(card);
            }

            Card previousCard = cards.FirstOrDefault();
            cards.RemoveAt(0);

            // Act & Assert
            foreach (Card card in cards)
            {
                Assert.IsTrue(previousCard.Power > card.Power);
                previousCard = card;
            }
        } 
    }
}
