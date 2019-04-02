using Pocker.Core.Entities;
using Pocker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocker.Core.Services
{
    public class TwoCardsPockerGame : IGame
    {
        private readonly IGameRule _gameRule;

        public TwoCardsPockerGame(IGameRule gameRule)
        {
            _gameRule = gameRule;
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
            deck.ShuffleMultiple(numberOfShuffles);

            // 2. Deal the cards to all the players
            foreach(var hand in round.PlayerHands)
            {
                deck.DealCards(hand);
            }

            // 3. Assess the cards for player and calculate points based on game rule
            foreach (var hand in round.PlayerHands)
            {
                
            }
        }
        
    }
}
