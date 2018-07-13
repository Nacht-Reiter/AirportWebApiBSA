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
        private IService<CrewDTO> Service;

        public CrewsController(IService<CrewDTO> service)
        {
            Service = service;
        }


        // GET: api/Crews
        [HttpGet]
        public JsonResult Get()
        {
            return Json(Service.GetAll());
        }

        // GET: api/Crews/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(Service.Get(id));
        }

        // POST: api/Crews
        [HttpPost]
        public void Post([FromBody]CrewDTO value)
        {
            Service.Create(value);
        }

        // PUT: api/Crews/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]CrewDTO value)
        {
            Service.Update(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Service.Delete(id);
        }
    }
}
