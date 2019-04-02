using Pocker.Core.Entities.Abstract;
using Pocker.Core.Exceptions;
using Pocker.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocker.Core.Entities
{
    public class Suite : BaseEntity
    {
        public string Type { get; private set; }

        public Suite(string type)
        {
            Type = type;
        }

        /// <summary>
        /// Make it simple by return a value directly. This could be enhanced via configuration or database setup
        /// Assumption: lowest rank card of a higher suite is more powerful than 
        /// highest rank card of its lower suite e.g. 2 Spades > A Clubs
        /// It means 
        ///     let say diamond power = 1
        ///     heart power > 7 times diamond power -> heart power = 10
        ///     club power > 7 times heart power -> club power = 100
        ///     spade power > 7 times club power -> spade power = 1000
        /// </summary>
        public int Power
        {
            get
            {
                switch(Type)
                {
                    case GlobalConstants.SUITE_SPADES: return 1000;
                    case GlobalConstants.SUITE_CLUBS: return 100;
                    case GlobalConstants.SUITE_HEARTS: return 10;
                    case GlobalConstants.SUITE_DIAMONDS: return 1;

                    default: throw new InvalidSuiteException(GlobalConstants.INVALID_SUITE_EXCEPTION);
                }
            }

        }
    }
}
