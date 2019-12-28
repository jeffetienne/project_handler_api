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
    public class DynamicReferenceByQuestionController : ApiController
    {
        private ApplicationDbContext _context;
        public DynamicReferenceByQuestionController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetQuestions(int id)
        {
            var question = _context.Questions.SingleOrDefault(q => q.Id == id);

            IList<DynamicReferenceByQuestion> dynamicReferences = _context
                .Database
                .SqlQuery<DynamicReferenceByQuestion>("GetDynamicReferenceByQuestion @questionId", new SqlParameter("@questionId", id))
                .ToList();
            for (int i = 0; i < dynamicReferences.Count; i++)
            {
                dynamicReferences.ElementAt(i).Question = question;
                var formulaire = _context.Formulaires.SingleOrDefault(f => f.Id == question.FormulaireId);
                dynamicReferences.ElementAt(i).Question.Formulaire = question.Formulaire;
            }
            return Ok(dynamicReferences.Select(Mapper.Map<DynamicReferenceByQuestion, DynamicReferenceByQuestionDTO>));
        }

        [HttpGet]
        [Route("api/DynamicReferenceByQuestion/{id}/{code}")]
        public IHttpActionResult GetReference(int id, string code)
        {
            var question = _context.Questions.SingleOrDefault(q => q.Id == id);

            IList<DynamicReferenceByQuestion> dynamicReferences = _context
                .Database
                .SqlQuery<DynamicReferenceByQuestion>("GetDynamicReferenceByCode @questionId, @code", new SqlParameter("@questionId", id), new SqlParameter("@code", code))
                .ToList();
            for (int i = 0; i < dynamicReferences.Count; i++)
            {
                dynamicReferences.ElementAt(i).Question = question;
                var formulaire = _context.Formulaires.SingleOrDefault(f => f.Id == question.FormulaireId);
                dynamicReferences.ElementAt(i).Question.Formulaire = question.Formulaire;
            }
            return Ok(dynamicReferences.Select(Mapper.Map<DynamicReferenceByQuestion, DynamicReferenceByQuestionDTO>));
        }
    }
}
