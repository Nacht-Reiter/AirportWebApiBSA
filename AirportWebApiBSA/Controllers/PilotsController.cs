using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportWebApiBSA.BLL.Interfaces;
using AirportWebApiBSA.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirportWebApiBSA.WEB.Controllers
{
    [Produces("application/json")]
    [Route("api/Pilots")]
    public class PilotsController : Controller
    {
        private IService<PilotDTO> Service;

        public PilotsController(IService<PilotDTO> service)
        {
            Service = service;
        }


        // GET: api/Pilots
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            return Json(await Service.GetAll());
        }

        // GET: api/Pilots/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            return Json(await Service.Get(id));
        }
        
        // POST: api/Pilots
        [HttpPost]
        public async Task Post([FromBody]PilotDTO value)
        {
            if (ModelState.IsValid)
            {
                await Service.Create(value);
            }
        }
        
        // PUT: api/Pilots/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PilotDTO value)
        {
            Service.Update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await Service.Delete(id);
            }
        }
    }
}
