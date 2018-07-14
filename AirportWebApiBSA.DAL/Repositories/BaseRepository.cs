using AirportWebApiBSA.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirportWebApiBSA.DAL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T: IModel
    {
        protected IList<T> ItemsList { get; set; }

        public virtual void Create(T item)
        {
            if(item != null)
            {
                ItemsList.Add(item);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public virtual void Delete(int id)
        {
            ItemsList.Remove(ItemsList.FirstOrDefault(i => i.Id == id));
        }

        public virtual IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return ItemsList.Where(predicate);
        }

        public virtual T Get(int id)
        {
            return ItemsList.FirstOrDefault(i => i.Id == id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return ItemsList;
        }

        public virtual void Update(T item)
        {
            ItemsList[ItemsList.IndexOf(ItemsList.FirstOrDefault(i => i.Id == item.Id))] = item;
        }
    }
}
