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
    public class TypeDonneesController : ApiController
    {
        private ApplicationDbContext _context;

        public TypeDonneesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetTypeDonnees()
        {
            return Ok(_context.TypeDonnees
                      .ToList()
                      .Select(Mapper.Map<TypeDonnee, TypeDonneeDTO>));
        }
    }
}
