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
    [Route("api/Stewardesses")]
    public class StewardessesController : Controller
    {
        private IService<StewardessDTO> Service;

        public StewardessesController(IService<StewardessDTO> service)
        {
            Service = service;
        }

        // GET: api/Stewardesses
        [HttpGet]
        public JsonResult Get()
        {
            return Json(Service.GetAll());
        }

        // GET: api/Stewardesses/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(Service.Get(id));
        }

        // POST: api/Stewardesses
        [HttpPost]
        public void Post([FromBody]StewardessDTO value)
        {
            Service.Create(value);
        }

        // PUT: api/Stewardesses/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]StewardessDTO value)
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
