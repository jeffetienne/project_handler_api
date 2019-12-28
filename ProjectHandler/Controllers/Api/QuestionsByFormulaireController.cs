using AutoMapper;
using ProjectHandler.Models;
using ProjectHandler.Models.Complex;
using ProjectHandler.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectHandler.Controllers.Api
{
    public class QuestionsByFormulaireController : ApiController
    {
        private ApplicationDbContext _context;
        public QuestionsByFormulaireController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetQuestions(int id)
        {
            var formulaire = _context.Formulaires.SingleOrDefault(f => f.Id == id);
            
            IList<QuestionsByFormulaire> questions = _context
                .Database
                .SqlQuery<QuestionsByFormulaire>("GetQuestionsByFormulaire @formulaireId", new SqlParameter("@formulaireId", id))
                .ToList();
            for(int i = 0; i<questions.Count; i++)
            {
                var idType = questions.ElementAt(i).TypeDonneeId;
                var idComponent = questions.ElementAt(i).TypeDonneeId;
                var typeDonnees = _context.TypeDonnees.SingleOrDefault(t => t.Id == idType);
                var component = _context.Components.SingleOrDefault(c => c.Id == idComponent);
                questions.ElementAt(i).Formulaire = formulaire;
                questions.ElementAt(i).TypeDonnee = typeDonnees;
                questions.ElementAt(i).Component = component;
            }
            return Ok(questions.Select(Mapper.Map<QuestionsByFormulaire, QuestionsByFormulaireDTO>));              
        }      
    }
}
