using Pocker.Core.Entities;
using Pocker.Core.Helpers;
using Pocker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocker.Core.Services
{
    public class DealerService : IDealerService
    {
        private readonly IGameRuleService _gameRule;

        public DealerService(IGameRuleService gameRule)
        {
            _gameRule = gameRule;
        }

        
        // <summary>
        /// Return the number of cards to the player
        /// </summary>
        public void DealCards(Deck deck, PlayerHand hand)
        {
            for (int i = 0; i < hand.NumberOfCards; i++)
            {
                Card card = deck.Cards.FirstOrDefault(x => !x.Visible);
                card.Visible = true;

                hand.Cards.Add(card);
            }
        }

        /// <summary>
        /// Shuffle the deck multiple times
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="times"></param>
        public void Shuffle(Deck deck, int times)
        {
            for(int i=0; i <times; i++)
            {
                ListUtility.Shuffle(deck.Cards);
            }
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
        public void CalculateHandRank(PlayerHand hand)
        {
            var cards = hand.Cards;
            int result = 1;

            if (_gameRule.IsStraightFlush(cards))
                result = 5;
            else if (_gameRule.IsFlush(cards))
                result = 4;
            else if (_gameRule.IsStraight(cards))
                result = 3;
            else if (_gameRule.HasPair(cards))
                result = 2;

            hand.HandRankPower = result;
        }

    }
}
