﻿using System;
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
    [Route("api/Departures")]
    public class DeparturesController : Controller
    {
        private IService<DepartureDTO> Service;

        public DeparturesController(IService<DepartureDTO> service)
        {
            Service = service;
        }


        // GET: api/Departures
        [HttpGet]
        public JsonResult Get()
        {
            return Json(Service.GetAll());
        }

        // GET: api/Departures/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(Service.Get(id));
        }

        // POST: api/Departures
        [HttpPost]
        public void Post([FromBody]DepartureDTO value)
        {
            if (ModelState.IsValid)
            {
                Service.Create(value);
            }
        }

        // PUT: api/Departures/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]DepartureDTO value)
        {
            Service.Update(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Service.Delete(id);
            }
        }
    }
}
