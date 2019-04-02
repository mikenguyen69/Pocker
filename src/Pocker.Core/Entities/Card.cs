using Pocker.Core.Entities.Abstract;
using System;

namespace Pocker.Core.Entities
{
    public class Card : BaseEntity
    {
        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }
        public bool Visible { get; set; }

        public Card(string suiteType, string rankType)
        {
            Suit = new Suit(suiteType);
            Rank = new Rank(rankType);
            Visible = false;
        }

        /// <summary>
        /// Card power is the multiple of its suite and rank power
        /// </summary>
        public int Power
        {
            get
            {
                return Suit.Power * Rank.Power;
            }
        }

        #region Helpers
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Card card = (Card)obj;
                return card.Suit.Power == Suit.Power && card.Rank.Power == Rank.Power;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Rank.Type, Suit.Type);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
