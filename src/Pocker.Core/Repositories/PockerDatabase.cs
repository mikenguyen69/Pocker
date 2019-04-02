using Poker.Core.Entities;
using Poker.Core.Entities.Abstract;
using Poker.Core.Helpers;
using Poker.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Poker.Core.Repositories
{
    public class PockerDatabase : IPockerDatabase
    {
        private static Hashtable dataStore = new Hashtable();

        public PockerDatabase()
        {
            dataStore[typeof(Player)] = new List<Player>()
            {
                new Player("Mike"),
                new Player("Teodora"),
                new Player("Clive"),
                new Player("John"),
                new Player("Crystal"),
                new Player("Alex"),
                new Player("Matt"),
                new Player("Tom"),
            };
        }
        public IList<T> Set<T>() where T : BaseEntity
        {
            return (IList<T>)dataStore[typeof(T)];
        }

        public void Save<T>(T entity) where T : BaseEntity
        {
            var currentSet = Set<T>();

            currentSet.Add(entity);

            dataStore[typeof(T)] = currentSet;
        }
    }
}
