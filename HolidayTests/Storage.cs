using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Holiday;

namespace HolidayTests
{
    public class Storage : IStorage
    {
        private readonly List<HolidayRequest> requests = new List<HolidayRequest>();
        private readonly List<Employee> employees = new List<Employee>();

        private readonly Dictionary<Type, IList> lists = new Dictionary<Type, IList>();

        public Storage()
        {
            lists.Add(typeof(HolidayRequest), requests);
            lists.Add(typeof(Employee), employees);
        }

        public IQueryable<T> GetStorageFor<T>() where T: class
        {
            if (lists.ContainsKey(typeof (T)))
                return (GetListFor<T>()).AsQueryable();

            return null;
        }

        private IList<T> GetListFor<T>() where T: class
        {
            return lists[typeof (T)] as IList<T>;
        }

        public void Add<T>(T entity) where T : class
        {
            GetListFor<T>().Add(entity);
        }
    }
}