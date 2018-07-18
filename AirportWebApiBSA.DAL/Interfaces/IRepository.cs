using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirportWebApiBSA.DAL.Interfaces
{ 
    public interface IRepository<T> where T : IModel
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Create(T item);
        void Update(T item);
        Task Delete(int id);
    }
}
