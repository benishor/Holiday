using System;
using System.Collections;
using System.Collections.Generic;
using Holiday;

namespace HolidayTests
{
    public class Storage
    {
        private readonly List<HolidayRequest> requests = new List<HolidayRequest>();
        private readonly List<Employee> employees = new List<Employee>();

        private readonly Dictionary<Type, IList> lists = new Dictionary<Type, IList>();

        public Storage()
        {
            lists.Add(typeof(HolidayRequest), requests);
            lists.Add(typeof(Employee), employees);
        }

        public ICollection<T> GetStorageFor<T>()
        {
            if (lists.ContainsKey(typeof (T)))
                return lists[typeof (T)] as ICollection<T>;

            return null;
        }
        
    }
}