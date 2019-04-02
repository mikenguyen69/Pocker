using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pocker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocker.Core.Tests.Entities
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
        public void NewDeckShouldHave52CardsInvisible()
        {
            // Arrange
            
            // Act
            var cards = deck.GetCards();

            // Assert
            Assert.AreEqual(52, cards.Count(x => !x.Visible));
        }

        [TestMethod]
        public void ShuffleShouldMakeTheCardSequenceDifferent()
        {
            // Arrange 
            deck.ShuffleMultiple(1);
            var before = Clone(deck.GetCards());
            deck.ShuffleMultiple(1);
            var after = Clone(deck.GetCards());

            // Act && Assert
            Assert.IsTrue(HasDifferentSequences(before, after));
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

            foreach(var card in cards)
            {
                newCards.Add(card);
            }

            return newCards;
        }

        #endregion
    }
}
