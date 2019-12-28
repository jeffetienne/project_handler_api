using ProjectHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using ProjectHandler.ViewModels;

namespace ProjectHandler.Controllers
{
    public class QuestionsController : Controller
    {
        private ApplicationDbContext _context;
        public QuestionsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Questions
        public ActionResult List()
        {
            return View("List");
        }
        public ActionResult Create()
        {
            var typeDonnees = _context.TypeDonnees.ToList();
            var components = _context.Components.ToList();
            var formulaires = _context.Formulaires.ToList();
            var questionViewModel = new QuestionViewModel
            {
                TypeDonnees = typeDonnees,
                Components = components,
                Formulaires = formulaires,
                Question = new Question(),
                DynamicReference = new DynamicReference()
            };
            return View("Create", questionViewModel);
        }
    }
}