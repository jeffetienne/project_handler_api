using AutoMapper;
using ProjectHandler.Models;
using ProjectHandler.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace ProjectHandler.Controllers.Api
{
    public class ReponseController : ApiController
    {
        private ApplicationDbContext _context;
        public ReponseController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetReponses()
        {
            return Ok(_context.Reponses
                      .Include(r => r.Question)
                      .ToList()
                      .Select(Mapper.Map<Reponse, ReponseDTO>));
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var reponse = _context.Reponses.Include(r => r.Question).SingleOrDefault(p => p.Id == id);
            if (reponse == null)
                return NotFound();
            return Ok(Mapper.Map<Reponse, ReponseDTO>(reponse));
        }

        [HttpPost]
        public IHttpActionResult CreateReponse(ReponseDTO reponseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var reponse = Mapper.Map<ReponseDTO, Reponse>(reponseDto);
            _context.Reponses.Add(reponse);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + reponse.Id), reponse);
        }

        [HttpPut]
        public void UpdateReponse(int id, ReponseDTO reponseDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var reponseInDb = _context.Reponses.SingleOrDefault(r => r.Id == id);

            if (reponseInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(reponseDto, reponseInDb);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteReponse(int id)
        {
            var reponseInDb = _context.Reponses.SingleOrDefault(r => r.Id == id);

            if (reponseInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Reponses.Remove(reponseInDb);
            _context.SaveChanges();
        }        
    }
}
