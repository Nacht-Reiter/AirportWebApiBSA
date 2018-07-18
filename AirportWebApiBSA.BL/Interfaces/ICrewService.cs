using AirportWebApiBSA.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirportWebApiBSA.BLL.Interfaces
{
    public interface ICrewService : IService<CrewDTO>
    {
        Task ReadFromRemoterAPI(string url);
    }
}
