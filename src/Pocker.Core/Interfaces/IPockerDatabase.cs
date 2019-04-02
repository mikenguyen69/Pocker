using Pocker.Core.Entities.Abstract;
using System.Collections.Generic;

namespace Pocker.Core.Interfaces
{
    public interface IPockerDatabase
    {
        IList<T> Set<T>() where T : BaseEntity;
        void Save<T>(T entity) where T : BaseEntity;
    }
}
