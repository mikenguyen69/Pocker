using Pocker.Core.Entities.Abstract;
using Pocker.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocker.Core.Repositories
{
    public class PockerDatabase : IPockerDatabase
    {
        private static Hashtable dataStore = new Hashtable();

        public PockerDatabase()
        {
            //dataStore[typeof(Employee)] = new List<Employee>();
            //dataStore[typeof(Payslip)] = new List<Payslip>();
            //dataStore[typeof(TaxBracket)] = new List<TaxBracket>()
            //{
            //    new TaxBracket(0, 18200, 0, 0),
            //    new TaxBracket(18201, 37000, 0, 0.19),
            //    new TaxBracket(37001, 87000, 3572, 0.325),
            //    new TaxBracket(87001, 180000, 19822, 0.37),
            //    new TaxBracket(180001, int.MaxValue, 54232, 0.45)
            //};
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
