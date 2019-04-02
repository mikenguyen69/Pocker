using Pocker.Core.Entities;
using Pocker.Core.Exceptions;
using Pocker.Core.Helpers;
using Pocker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocker.Core.Services
{
    public class TwoCardsGameRule : IGameRule
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

        /// <summary>
        /// Return values based on the strength of the cards on player hand
        /// 5 = Straight flush
        /// 4 = Flush
        /// 3 = Straight
        /// 2 = Pair
        /// 1 = High card
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public int GenerateHandCardsPower(IList<Card> cards)
        {
            int result = 1;

            if (IsStraightFlush(cards))
                result = 5;
            else if (IsFlush(cards))
                result = 4;
            else if (IsStraight(cards))
                result = 3;
            else if (HasPair(cards))
                result = 2;

            return result;
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
