using Poker.Core.Entities.Abstract;
using System.Collections.Generic;

namespace Poker.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IList<T> List();
        T Get(int id);
        void Add(T entity);
    }
}
