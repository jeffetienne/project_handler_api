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
    public class FormTypeController : ApiController
    {
        private ApplicationDbContext _context;

        public FormTypeController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetFormTypes()
        {
            return Ok(_context.TypeForms
                      .ToList()
                      .Select(Mapper.Map<TypeForm, TypeFormDTO>));
        }

        [HttpGet]
        public IHttpActionResult GetFormType(int id)
        {
            var domaine = _context.TypeForms.SingleOrDefault(d => d.Id == id);
            if (domaine == null)
                return NotFound();
            return Ok(Mapper.Map<TypeForm, TypeFormDTO>(domaine));
        }
    }
}
