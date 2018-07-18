using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AirportWebApiBSA.Shared.DTOs;

namespace AirportWebApiBSA.BLL.Interfaces
{
    public interface IService<T> where T: IDTO
    {
        Task Create(T item);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        void Update(int id, T item);
        Task Delete(int id);
    }
}
