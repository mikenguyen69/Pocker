using Pocker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocker.Core.Interfaces
{
    public interface IGameRule
    {
        bool HasStraightFlush(PlayerHand hand);
        bool HasFlush(PlayerHand hand);
        bool HasStraight(PlayerHand hand);
        bool HasPair(PlayerHand hand);
    }
}
