using ProjectHandler.Models;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using ProjectHandler.Models.DTOs;
using System;
using System.Net;

namespace ProjectHandler.Controllers.Api
{
    public class ProjetController : ApiController
    {
        private ApplicationDbContext _context;

        public ProjetController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetProjets()
        {
            return Ok(_context.Projets
                      .Include(p => p.Domaine)
                      .ToList()
                      .Select(Mapper.Map<Projet,ProjetDTO>));
        }

        [HttpGet]
        public IHttpActionResult GetProjet(int id)
        {
            var projet = _context.Projets.Include(p => p.Domaine).SingleOrDefault(p => p.Id == id);
            if (projet == null)
                return NotFound();
            return Ok(Mapper.Map<Projet, ProjetDTO>(projet));
        }

        [HttpPost]
        public IHttpActionResult CreateProjet(ProjetDTO projetDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var projet = Mapper.Map<ProjetDTO, Projet>(projetDto);
            _context.Projets.Add(projet);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + projet.Id), projet);
        }

        [HttpPut]
        public void UpdateProjet(int id, ProjetDTO projetDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var projetInDb = _context.Projets.SingleOrDefault(p => p.Id == id);

            if (projetInDb == null)
                 throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(projetDto, projetInDb);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteProjet(int id)
        {
            var projetInDb = _context.Projets.SingleOrDefault(p => p.Id == id);

            if (projetInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Projets.Remove(projetInDb);
            _context.SaveChanges();
        }
    }
}
