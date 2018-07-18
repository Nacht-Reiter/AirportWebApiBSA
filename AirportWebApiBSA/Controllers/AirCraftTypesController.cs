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
        public async Task<JsonResult> Get()
        {
            return Json(await Service.GetAll());
        }

        // GET: api/AirCraftTypes/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            return Json(await Service.Get(id));
        }

        // POST: api/AirCraftTypes
        [HttpPost]
        public async Task Post([FromBody]AirCraftTypeDTO value)
        {
            if (ModelState.IsValid)
            {
                await Service.Create(value);
            }
        }

        // PUT: api/AirCraftTypes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]AirCraftTypeDTO value)
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
