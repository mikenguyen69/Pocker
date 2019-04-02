using Poker.Core.Entities;
using Poker.Core.Exceptions;
using Poker.Core.Helpers;
using Poker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Core.Services
{
    public class TwoCardsGameRule : IGameRuleService
    {
        /// <summary>
        /// 2 cards of sequential rank, same suit
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public bool IsStraightFlush(IList<Card> cards)
        {
            HandleCardsMissingException(cards);

            return SameSuit(cards) && GetRankPowerDifferent(cards[0], cards[1]) == 1;
        }

        /// <summary>
        /// 2 cards of same suit
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public bool IsFlush(IList<Card> cards)
        {
            HandleCardsMissingException(cards);

            return SameSuit(cards) && GetRankPowerDifferent(cards[0], cards[1]) > 1;
        }

        /// <summary>
        /// 2 cards of sequential rank, different suit
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public bool IsStraight(IList<Card> cards)
        {
            HandleCardsMissingException(cards);

            return !SameSuit(cards) && GetRankPowerDifferent(cards[0], cards[1]) == 1;
        }

        /// <summary>
        /// 2 cards of same rank
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public bool HasPair(IList<Card> cards)
        {
            HandleCardsMissingException(cards);

            return !SameSuit(cards) && GetRankPowerDifferent(cards[0], cards[1]) == 0;
        }

        #region Helpers
        private bool SameSuit(IList<Card> cards)
        {
            Suit suit = cards.FirstOrDefault().Suit;

            return cards.All(x => x.Suit.Equals(suit));
        }

        private bool SameRank(IList<Card> cards)
        {
            Rank rank = cards.FirstOrDefault().Rank;

            return cards.All(x => x.Rank.Equals(rank));
        }

        private int GetRankPowerDifferent(Card card1, Card card2)
        {
            return Math.Abs(card1.Rank.Power - card2.Rank.Power);
        }

        private void HandleCardsMissingException(IList<Card> cards)
        {
            if (cards == null || cards.Count != 2)
                throw new InvalidNumberOfCardException(GlobalConstants.INVALID_NUMBEROFCARD_EXCEPTION);
        }

        #endregion
    }
}
