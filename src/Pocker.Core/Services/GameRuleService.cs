using Pocker.Core.Entities;
using Pocker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocker.Core.Services
{
    public class TwoCardsGameRule : IGameRule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public bool HasFlush(PlayerHand hand)
        {
            throw new NotImplementedException();
        }

        public bool HasPair(PlayerHand hand)
        {
            throw new NotImplementedException();
        }

        public bool HasStraight(PlayerHand hand)
        {
            throw new NotImplementedException();
        }

        public bool HasStraightFlush(PlayerHand hand)
        {
            throw new NotImplementedException();
        }
    }
}
