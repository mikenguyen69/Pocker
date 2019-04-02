using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Core.Entities;
using System.Linq;

namespace Poker.Core.Tests.Entities
{
    [TestClass]
    public class DeckTests
    {
        private readonly Deck deck;

        public DeckTests()
        {
            deck = new Deck();
        }

        [TestMethod]
        public void NewDeck_ShouldHave52CardsInvisible()
        {
            // Arrange
            
            // Act
            var cards = deck.Cards;

            // Assert
            Assert.AreEqual(52, cards.Count(x => !x.Visible));
        }
    }
}
