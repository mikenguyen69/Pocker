using Poker.Core.Entities;
using Poker.Core.Helpers;
using Poker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Core.Services
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

        public void AssignScore(GameRound round, int maxScore)
        {
            int currentCount = maxScore;
            foreach (var hand in round.PlayerHands.OrderByDescending(x => x.Power))
            {
                hand.Score = currentCount;

                if (currentCount == maxScore)
                {
                    round.UpdateWinner(hand);
                }

                currentCount--;
            }
        }

        public IList<Player> GetWinners(TwoCardsGame game)
        {
            // Get all records of player and his/her play hands
            var playerRecords = game.GameRounds.SelectMany(x => x.PlayerHands).GroupBy(x => x.Player);

            // Find the max total score first
            int maxScore = playerRecords.Max(x => x.Sum(b => b.Score));

            // Winners are those having the same max score
            var winners = playerRecords.Where(x => x.Sum(b => b.Score) == maxScore).Select(c => c.Key);

            game.WinningScore = maxScore;

            return winners.ToList();
        }
    }
}
