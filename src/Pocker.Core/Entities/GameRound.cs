using Pocker.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocker.Core.Entities
{
    public class GameRound : BaseEntity
    {
        public IList<PlayerHand> PlayerHands { get; set; }
        public PlayerHand RoundWinner { get; set; }
        public bool Finished { get; set; }

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
    }
}
