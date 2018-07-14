using System;
using System.Collections.Generic;
using System.Text;
using AirportWebApiBSA.Shared.DTOs;

namespace AirportWebApiBSA.BLL.Interfaces
{
    public interface IService<T> where T: IDTO
    {
        void Create(T item);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Update(int id, T item);
        void Delete(int id);
    }
}
