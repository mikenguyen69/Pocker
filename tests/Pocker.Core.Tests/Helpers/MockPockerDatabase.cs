using Pocker.Core.Entities;
using Pocker.Core.Entities.Abstract;
using Pocker.Core.Helpers;
using Pocker.Core.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Pocker.Core.Tests.Helpers
{
    public class MockPockerDatabase : IPockerDatabase
    {
        private static Hashtable dataStore = new Hashtable();

        public MockPockerDatabase()
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
