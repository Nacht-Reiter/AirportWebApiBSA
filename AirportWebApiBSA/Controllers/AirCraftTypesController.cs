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
    [Route("api/AirCraftTypes")]
    public class AirCraftTypesController : Controller
    {
        private IService<AirCraftTypeDTO> Service;

        public AirCraftTypesController(IService<AirCraftTypeDTO> service)
        {
            Service = service;
        }


        // GET: api/AirCraftTypes
        [HttpGet]
        public JsonResult Get()
        {
            return Json(Service.GetAll());
        }

        // GET: api/AirCraftTypes/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(Service.Get(id));
        }

        // POST: api/AirCraftTypes
        [HttpPost]
        public void Post([FromBody]AirCraftTypeDTO value)
        {
            Service.Create(value);
        }

        // PUT: api/AirCraftTypes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]AirCraftTypeDTO value)
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
