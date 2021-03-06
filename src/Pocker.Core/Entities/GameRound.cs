﻿using Pocker.Core.Entities.Abstract;
using System.Collections.Generic;

namespace Pocker.Core.Entities
{
    public class GameRound : BaseEntity
    {
        public IList<PlayerHand> PlayerHands { get; set; }
        public PlayerHand RoundWinner { get; protected set; }
        public bool Finished { get; protected set; }

        public GameRound(IList<Player> players, int numberOfCards)
        {
            Finished = false;

            PlayerHands = new List<PlayerHand>();

            foreach (Player player in players)
            {
                PlayerHand hand = new PlayerHand(player, numberOfCards);
                PlayerHands.Add(hand);
            }
        }

        public void UpdateWinner(PlayerHand winner)
        {
            RoundWinner = winner;
            Finished = true;
        }
    }
}
