using Pocker.Core.Entities.Abstract;
using Pocker.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pocker.Core.Entities
{
    public class Deck : BaseEntity
    {
        private static Random rng = new Random();
        private IList<Card> cards;

        /// <summary>
        /// Setup the decks of 52 cards when initalizing a new deck
        /// </summary>
        public Deck()
        {
            cards = new List<Card>();

            // 4 suites
            foreach(string suite in GlobalConstants.SUITE_LIST)
            {
                // 13 ranks
                foreach(string rank in GlobalConstants.RANK_LIST)
                {
                    Card card = new Card(suite, rank);
                    cards.Add(card);
                }
            }
        }

        public IList<Card> GetCards()
        {
            return cards;
        }

        /// <summary>
        /// Reset will be used for each new game
        /// </summary>
        public void Reset()
        {
            foreach(Card card in cards.Where(x => !x.Visible))
            {
                card.Visible = false;
            }
        }

        /// <summary>
        /// Return the number of cards to the player
        /// </summary>
        public IList<Card> DealCards(int numberOfCard)
        {
            IList<Card> returnCards = new List<Card>();

            for(int i=0; i < numberOfCard; i++)
            {
                Card card = cards.FirstOrDefault(x => !x.Visible);
                card.Visible = true;

                returnCards.Add(card);
            }
            
            return returnCards;
        }

        public void ShuffleMultiple(int times)
        {
            for (int i = 0; i < times; i++)
                Shuffle();
        }

        #region Helpers
        /// <summary>
        /// Due to the randomness, it is not 100% that the card sequences are differents before each shuffling
        /// Shuffle deck via Knuth shuffle algorithm 
        /// https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        /// </summary>
        private void Shuffle()
        {
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
        #endregion
    }
}
