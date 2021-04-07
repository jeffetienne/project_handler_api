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
    public class MaxGroupeController : ApiController
    {
        private ApplicationDbContext _context;
        public MaxGroupeController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetMaxGroupe()
        {

            IList<ReponsesByFormulaire> reponses = _context
                .Database
                .SqlQuery<ReponsesByFormulaire>("GetMaxGroupe")
                .ToList();


            return Ok(reponses.Select(Mapper.Map<ReponsesByFormulaire, ReponsesByFormulaireDTO>));
        }
    }
}
