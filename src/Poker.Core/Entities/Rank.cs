using Poker.Core.Entities.Abstract;
using Poker.Core.Exceptions;
using Poker.Core.Helpers;

namespace Poker.Core.Entities
{
    public class Rank : BaseEntity
    {
        public string Type { get; private set; }

        public Rank(string type)
        {
            Type = type;
        }

        /// <summary>
        /// Make it simple by return a value directly. This could be enhanced via configuration or database setup
        /// </summary>
        public int Power
        {
            get
            {
                switch(Type)
                {
                    case GlobalConstants.RANK_A: return 14;
                    case GlobalConstants.RANK_K: return 13;
                    case GlobalConstants.RANK_Q: return 12;
                    case GlobalConstants.RANK_J: return 11;
                    case GlobalConstants.RANK_10: return 10;
                    case GlobalConstants.RANK_9: return 9;
                    case GlobalConstants.RANK_8: return 8;
                    case GlobalConstants.RANK_7: return 7;
                    case GlobalConstants.RANK_6: return 6;
                    case GlobalConstants.RANK_5: return 5;
                    case GlobalConstants.RANK_4: return 4;
                    case GlobalConstants.RANK_3: return 3;
                    case GlobalConstants.RANK_2: return 2;

                    default: throw new InvalidRankException(GlobalConstants.INVALID_RANK_EXCEPTION);
                }
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
                var rank = (Rank)obj;
                return rank.Type == Type && rank.Power == Power;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
