using Pocker.Core.Entities.Abstract;
using System;

namespace Pocker.Core.Entities
{
    public class Card : BaseEntity
    {
        public Suite Suite { get; private set; }
        public Rank Rank { get; private set; }
        public bool Visible { get; set; }

        public Card(string suiteType, string rankType)
        {
            Suite = new Suite(suiteType);
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
                return Suite.Power * Rank.Power;
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
                return card.Suite.Power == Suite.Power && card.Rank.Power == Rank.Power;
            }
        }
        #endregion
    }
}
