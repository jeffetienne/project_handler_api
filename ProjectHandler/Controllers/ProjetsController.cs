using ProjectHandler.Models;
using ProjectHandler.Models.Complex;
using ProjectHandler.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHandler.Controllers
{
    public class ProjetsController : Controller
    {
        private ApplicationDbContext _context;
        public ProjetsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Projets
        public ActionResult List()
        {
            //var formulaireIdParameter = new SqlParameter();
            //formulaireIdParameter.ParameterName = "@formulaireId";
            //formulaireIdParameter.Direction = ParameterDirection.Input;
            //formulaireIdParameter.SqlDbType = SqlDbType.Int;
            //var questions = _context.Database.ExecuteSqlCommand("GetQuestionsByFormulaire @formulaireId",
            //    new SqlParameter("@formulaireId", "1"));

            //Console.WriteLine(questions);
            IList<QuestionsByFormulaire> questions = _context
                .Database
                .SqlQuery<QuestionsByFormulaire>("GetQuestionsByFormulaire @formulaireId", new SqlParameter("@formulaireId", "1"))
                .ToList();

            Console.WriteLine(questions.First().Name);

            return View("List");
        }

        public ActionResult Create()
        {
            var domaines = _context.Domaines.ToList();
            var viewModel = new ProjetViewModel
            {
                Projet = new Projet(),
                Domaines = domaines

            };
            return View("Create", viewModel);
        }
        public ActionResult Created()
        {
            return View("List");
        }
        public ActionResult Edit(int id)
        {
            var projet = _context.Projets.SingleOrDefault(p => p.Id == id);
            if (projet == null)
                return HttpNotFound();

            var viewModel = new ProjetViewModel
            {
                Projet = projet,
                Domaines = _context.Domaines.ToList()
            };

            return View("Create", viewModel);
        }
    }
}