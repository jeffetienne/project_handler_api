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
    public class DomaineController : ApiController
    {
        private ApplicationDbContext _context;

        public DomaineController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetDomaines()
        {
            var domaines = _context.Domaines;
            //var result = (domaines == null ? NotFound() : Ok(domaines.ToList()
            //          .Select(Mapper.Map<Domaine, DomaineDTO>)));
            if (domaines == null)
                return NotFound();
            return Ok(domaines
                      .ToList()
                      .Select(Mapper.Map<Domaine, DomaineDTO>));
        }

        [HttpGet]
        public IHttpActionResult GetDomaine(int id)
        {
            var domaine = _context.Domaines.SingleOrDefault(d => d.Id == id);
            if (domaine == null)
                return NotFound();
            return Ok(Mapper.Map<DomaineDTO>(domaine));
        }
    }
}
