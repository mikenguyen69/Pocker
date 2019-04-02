using Pocker.Core.Entities.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Pocker.Core.Entities
{
    public class PlayerHand : BaseEntity
    {
        public Player Player { get; set; }
        public IList<Card> Cards { get; set; }
        public int NumberOfCards { get; set; }
        public int HandRankPower { get; set; }

        /// <summary>
        /// Hand's power of the hand is calculated based on CardsPower x Strongest cards power
        /// It is used to compare the strength of player hand
        /// </summary>
        public int Power
        {
            get
            {
                return HandRankPower * Cards.Max(x => x.Power);
            }
        }

        public int Score { get; set; }

        public PlayerHand(Player player, int numberOfCards)
        {
            Player = player;
            NumberOfCards = numberOfCards;
            Cards = new List<Card>();
        }
    }
}
