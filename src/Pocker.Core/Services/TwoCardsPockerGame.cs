using Pocker.Core.Entities;
using Pocker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocker.Core.Services
{
    public class TwoCardsPockerGame : IGameService
    {
        private readonly IGameRuleService _gameRule;
        private readonly IDealerService _dealer;

        public TwoCardsPockerGame(IGameRuleService gameRule, IDealerService dealer)
        {
            _gameRule = gameRule;
            _dealer = dealer;
        }

        /// <summary>
        /// Beginning of each round, the deck will be shuffled first
        /// Then deal to all the PlayerHand
        /// The winnder of the round will be the one having highest score
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="round"></param>
        public void Play(Deck deck, int numberOfShuffles, GameRound round)
        {
            // 1. Shuffle the deck
            _dealer.Shuffle(deck, numberOfShuffles);

            // 2. Deal the cards to all the players
            foreach(var hand in round.PlayerHands)
            {
                _dealer.DealCards(deck, hand);

                // 3. Calculate the power of all cards on each player hand
                _dealer.CalculateHandRank(hand);
            }

            // 4. Nominal the score to 0 – weakest to strongest x-1(where x = number of players)
            // Just simply sort the player hands by power desc and then pick the first one as the winner
            int currentCount = round.PlayerHands.Count;
            foreach(var hand in round.PlayerHands.OrderByDescending(x => x.Power))
            {
                hand.Score = currentCount;

                if (currentCount == round.PlayerHands.Count)
                {
                    round.UpdateWinner(hand);
                }

                currentCount--;
            }
        }
        
    }
}
