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
    [Route("api/Tickets")]
    public class TicketsController : Controller
    {
        private IService<TicketDTO> Service;

        public TicketsController(IService<TicketDTO> service)
        {
            Service = service;
        }


        // GET: api/Tickets
        [HttpGet]
        public JsonResult Get()
        {
            return Json(Service.GetAll());
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(Service.Get(id));
        }

        // POST: api/Tickets
        [HttpPost]
        public void Post([FromBody]TicketDTO value)
        {
            Service.Create(value);
        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TicketDTO value)
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
