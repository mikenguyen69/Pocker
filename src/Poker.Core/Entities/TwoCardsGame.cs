using Poker.Core.Entities.Abstract;
using Poker.Core.Exceptions;
using Poker.Core.Helpers;
using System.Collections.Generic;

namespace Poker.Core.Entities
{
    public class TwoCardsGame : Game
    {
        public TwoCardsGame(IList<Player> players, int numberOfRounds) :
            base(players, numberOfRounds, 2)
        {
            
        }
    }
}
