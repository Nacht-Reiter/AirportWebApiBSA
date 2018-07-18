using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportWebApiBSA.BLL.Interfaces;
using AirportWebApiBSA.DAL.Models;
using AirportWebApiBSA.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AirportWebApiBSA.WEB.Controllers
{
    [Produces("application/json")]
    [Route("api/Crews")]
    public class CrewsController : Controller
    {
        private ICrewService Service;

        public CrewsController(ICrewService service)
        {
            Service = service;
        }

        // GET: api/Crews
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            return Json(await Service.GetAll());
        }

        // GET: api/Crews/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            return Json(await Service.Get(id));
        }

        // GET: api/Crews/RemoteAPI
        [HttpGet("RemoteAPI")]
        public async Task ReadFromRemoteAPI()
        {
            await Service.ReadFromRemoterAPI("http://5b128555d50a5c0014ef1204.mockapi.io/crew");
        }

        // POST: api/Crews
        [HttpPost]
        public async Task Post([FromBody]CrewDTO value)
        {
            if (ModelState.IsValid)
            {
                await Service.Create(value);
            }
        }

        // PUT: api/Crews/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]CrewDTO value)
        {
            if (ModelState.IsValid)
            {
                Service.Update(id, value);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await Service.Delete(id);
        }
    }
}
