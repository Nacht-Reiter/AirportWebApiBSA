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
    [Route("api/AirCrafts")]
    public class AirCraftController : Controller
    {
        private IService<AirCraftDTO> Service;

        public AirCraftController(IService<AirCraftDTO> service)
        {
            Service = service;
        }


        // GET: api/AirCrafts
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            return Json(await Service.GetAll());
        }

        // GET: api/AirCrafts/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            return Json(await Service.Get(id));
        }

        // POST: api/AirCrafts
        [HttpPost]
        public async Task Post([FromBody]AirCraftDTO value)
        {
            if (ModelState.IsValid)
            {
                await Service.Create(value);
            }
        }

        // PUT: api/AirCrafts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]AirCraftDTO value)
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
