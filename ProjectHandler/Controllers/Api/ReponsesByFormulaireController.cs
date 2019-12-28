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

namespace ProjectHandler.Controllers.Api
{
    public class ReponsesByFormulaireController : ApiController
    {
        private ApplicationDbContext _context;
        public ReponsesByFormulaireController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetReponses(int id)
        {
            var formulaire = _context.Formulaires.SingleOrDefault(f => f.Id == id);
            var question = new Question();
            int questionId = 0;
            
            IList<Reponse> reponses = _context
                .Database
                .SqlQuery<Reponse>("GetReponsesByFormulaire @formId", new SqlParameter("@formId", id))
                .ToList();
            for (int i = 0; i < reponses.Count; i++)
            {
                questionId = reponses.ElementAt(i).QuestionId;
                question = _context.Questions.SingleOrDefault(q => q.Id == questionId);
                 
                reponses.ElementAt(i).Question = question;
            }
            return Ok(reponses.Select(Mapper.Map<Reponse, ReponseDTO>));
        }
    }
}
