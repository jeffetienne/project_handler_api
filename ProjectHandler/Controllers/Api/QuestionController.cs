using ProjectHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using ProjectHandler.Models.DTOs;
using System.Data.SqlClient;
using System.Data;

namespace ProjectHandler.Controllers.Api
{
    public class QuestionController : ApiController
    {
        private ApplicationDbContext _context;
        public QuestionController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet]
        public IHttpActionResult GetQuestions()
        {

            //var formulaireIdParameter = new SqlParameter();
            //formulaireIdParameter.ParameterName = "@formulaireId";
            //formulaireIdParameter.Direction = ParameterDirection.Input;
            //formulaireIdParameter.SqlDbType = SqlDbType.Int;
            //var questions = _context.Database.ExecuteSqlCommand("GetQuestionsByFormulaire @formulaireId",
            //    new SqlParameter("@formulaireId", "1"),
            //    formulaireIdParameter);

            return Ok(_context
                .Questions
                .Include(q => q.Component)
                .Include(q => q.TypeDonnee)
                .Include(q => q.Formulaire)
                .ToList()
                .Select(Mapper.Map<Question,QuestionDTO>));
        }
        [HttpGet]
        public IHttpActionResult GetQuestion(int id)
        {
            var question = _context
                .Questions
                .Include(q => q.Component)
                .Include(q => q.TypeDonnee)
                .Include(q => q.Formulaire)
                .SingleOrDefault(q => q.Id == id);

            if (question == null)
                return NotFound();

            return Ok(Mapper.Map<Question, QuestionDTO>(question));
        }
        [HttpPost]
        public IHttpActionResult CreateQuestion(QuestionDTO questionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var question = Mapper.Map<QuestionDTO, Question>(questionDto);
            _context.Questions.Add(question);
            _context.SaveChanges();

            questionDto.Id = question.Id;
            return Created(new Uri(Request.RequestUri + "/" + question.Id), question);
        }
        [HttpPut]
        public void UpdateQuestion(int id, QuestionDTO questionDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var questionInDb = _context
                .Questions
                .SingleOrDefault(q => q.Id == id);

            if (questionInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(questionDto, questionInDb);
            _context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteQuestion(int id)
        {
            var question = _context
                .Questions
                .Include(q => q.Component)
                .Include(q => q.TypeDonnee)
                .Include(q => q.Formulaire)
                .SingleOrDefault(q => q.Id == id);

            if (question == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Questions.Remove(question);
            _context.SaveChanges();
        }
    }
}
