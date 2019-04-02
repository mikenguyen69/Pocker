using Poker.Core.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Poker.Core.Helpers
{
    public static class ListUtility
    {
        private static Random rng = new Random();

        /// <summary>
        /// Due to the randomness, it is not 100% that the card sequences are differents before each shuffling
        /// Shuffle deck via Knuth shuffle algorithm 
        /// https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        /// </summary>
        public static void Shuffle<T>(IList<T> items) where T : BaseEntity
        {
            
            int n = items.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = items[k];
                items[k] = items[n];
                items[n] = value;
            }
        }
    }
}
