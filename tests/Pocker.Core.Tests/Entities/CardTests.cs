using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pocker.Core.Entities;
using Pocker.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocker.Core.Tests.Entities
{
    [TestClass]
    public class CardTests
    {
        [DataRow(GlobalConstants.SUITE_SPADES, GlobalConstants.SUITE_CLUBS)]
        [DataRow(GlobalConstants.SUITE_CLUBS, GlobalConstants.SUITE_HEARTS)]
        [DataRow(GlobalConstants.SUITE_HEARTS, GlobalConstants.SUITE_DIAMONDS)]
        [DataTestMethod]
        public void DifferentSuite_LowestRankOfHigherSuiteIsMorePowerThanHighestRankofLowerSuite(string highSuite, string lowSuite)
        {
            // Arrange 
            Card highCard = new Card(highSuite, GlobalConstants.RANK_2);
            Card lowCard = new Card(lowSuite, GlobalConstants.RANK_A);

            // Act
            bool stronger = highCard.Power > lowCard.Power;

            // Assert
            Assert.IsTrue(stronger);
        }

        [DataRow(GlobalConstants.SUITE_SPADES)]
        [DataRow(GlobalConstants.SUITE_CLUBS)]
        [DataRow(GlobalConstants.SUITE_HEARTS)]
        [DataRow(GlobalConstants.SUITE_DIAMONDS)]
        [DataTestMethod]
        public void SameSuite_HigherRankIsMorePowerful(string suite)
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
