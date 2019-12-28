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
    public class ReponseByQuestionController : ApiController
    {
        private ApplicationDbContext _context;
        public ReponseByQuestionController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetReponse(int id)
        {
            var question = _context.Questions.SingleOrDefault(q => q.Id == id);

            IList<Reponse> reponse = _context
                .Database
                .SqlQuery<Reponse>("GetReponseByQuestion @questionId", new SqlParameter("@questionId", id))
                .ToList();
            for (int i = 0; i < reponse.Count; i++)
            {
                reponse.ElementAt(i).Question = question;
            }
            return Ok(reponse.Select(Mapper.Map<Reponse, ReponseDTO>));
        }
    }
}
