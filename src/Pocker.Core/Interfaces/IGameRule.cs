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
        bool IsStraightFlush(IList<Card> cards);
        bool IsFlush(IList<Card> cards);
        bool IsStraight(IList<Card> cards);
        bool HasPair(IList<Card> cards);
    }
}
