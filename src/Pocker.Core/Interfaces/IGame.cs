using Pocker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocker.Core.Interfaces
{
    public interface IGame
    {
        void Play(Deck deck, int numberOfShuffle, GameRound round);
    }
}
