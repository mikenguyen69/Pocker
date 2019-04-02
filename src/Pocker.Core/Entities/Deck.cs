using Poker.Core.Entities.Abstract;
using Poker.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Core.Entities
{
    public class Deck : BaseEntity
    {
        public IList<Card> Cards { get; protected set; }

        /// <summary>
        /// Setup the decks of 52 cards when initalizing a new deck
        /// </summary>
        public Deck()
        {
            Cards = new List<Card>();

            // 4 suites
            foreach(string suite in GlobalConstants.SUITE_LIST)
            {
                // 13 ranks
                foreach(string rank in GlobalConstants.RANK_LIST)
                {
                    Card card = new Card(suite, rank);
                    Cards.Add(card);
                }
            }
        }

        /// <summary>
        /// Reset will be used for each new game
        /// </summary>
        public void Reset()
        {
            foreach(Card card in Cards.Where(x => !x.Visible))
            {
                card.Visible = false;
            }
        }
    }
}
