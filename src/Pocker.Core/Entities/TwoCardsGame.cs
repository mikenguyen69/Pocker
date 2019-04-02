using Pocker.Core.Entities.Abstract;
using Pocker.Core.Exceptions;
using Pocker.Core.Helpers;
using System.Collections.Generic;

namespace Pocker.Core.Entities
{
    public class TwoCardsGame : Game
    {
        public TwoCardsGame(IList<Player> players, int numberOfRounds) :
            base(players, numberOfRounds, 2)
        {
            
        }
    }
}
