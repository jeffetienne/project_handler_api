using AutoMapper;
using ProjectHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using ProjectHandler.Models.DTOs;

namespace ProjectHandler.Controllers.Api
{
    public class FormulaireController : ApiController
    {
        private ApplicationDbContext _context;
        public FormulaireController ()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet]
        public IHttpActionResult GetFormulaires()
        {
            return Ok(_context
                .Formulaires
                .Include(f => f.TypeForm)
                .Include(f => f.Projet)
                .ToList()
                .Select(Mapper.Map<Formulaire, FormulaireDTO>));
        }
        [HttpGet]
        public IHttpActionResult GetFormulaire(int id)
        {
            var formulaire = _context
                .Formulaires.
                Include(f => f.TypeForm)
                .Include(f => f.Projet)
                .SingleOrDefault(f => f.Id == id);

            if (formulaire == null)
                return BadRequest();
            return Ok(Mapper.Map<Formulaire, FormulaireDTO>(formulaire));
        }
        [HttpPost]
        public IHttpActionResult CreateFormulaire(FormulaireDTO formulaireDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var formulaire = Mapper.Map<FormulaireDTO, Formulaire>(formulaireDto);
            _context.Formulaires.Add(formulaire);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + formulaire.Id), formulaire);
        }
        [HttpPut]
        public void UpdateFormulaire(int id, FormulaireDTO formulaireDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var formulaireInDb = _context.Formulaires.SingleOrDefault(f => f.Id == id);
            if (formulaireInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(formulaireDto, formulaireInDb);
            _context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteFormulaire(int id)
        {
            var FormulaireInDb = _context.Formulaires.SingleOrDefault(f => f.Id == id);

            if (FormulaireInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Formulaires.Remove(FormulaireInDb);
            _context.SaveChanges();
        }
    }
}
