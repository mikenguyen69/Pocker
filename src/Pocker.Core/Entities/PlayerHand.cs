using Pocker.Core.Entities.Abstract;
using System.Collections.Generic;
namespace Pocker.Core.Entities
{
    public class PlayerHand : BaseEntity
    {
        public Player Player { get; set; }
        public IList<Card> Cards { get; set; }
        public int NumberOfCards { get; set; }

        public PlayerHand(Player player, int numberOfCards)
        {
            Player = player;
            NumberOfCards = numberOfCards;
            Cards = new List<Card>();
        }
    }
}
