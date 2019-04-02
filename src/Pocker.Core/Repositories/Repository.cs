using Poker.Core.Entities.Abstract;
using Poker.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private IPockerDatabase _database;

        public Repository(IPockerDatabase database)
        {
            _database = database;
        }

        public void Add(T entity)
        {
            _database.Save(entity);
        }

        public T Get(int id)
        {
            return _database.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public IList<T> List()
        {
            return _database.Set<T>();
        }
    }
}
