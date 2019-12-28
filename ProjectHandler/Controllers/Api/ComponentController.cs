using AutoMapper;
using ProjectHandler.Models;
using ProjectHandler.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectHandler.Controllers.Api
{
    
    public class ComponentController : ApiController
    {
        private ApplicationDbContext _context;

        public ComponentController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetComponents()
        {
            return Ok(_context.Components
                      .ToList()
                      .Select(Mapper.Map<Component, ComponentDTO>));
        }
        [HttpPost]
        public IHttpActionResult CreateComponent(ComponentDTO componentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var component = Mapper.Map<ComponentDTO, Component>(componentDto);
            _context.Components.Add(component);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + component.Id), component);
        }

    }
}
