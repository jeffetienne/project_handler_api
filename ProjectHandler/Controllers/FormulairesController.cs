using ProjectHandler.Models;
using ProjectHandler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectHandler.Controllers
{
    public class FormulairesController : Controller
    {
        private ApplicationDbContext _context;
        public FormulairesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult List()
        {
            return View("List");
        }

        public ActionResult Create()
        {
            var typeForms = _context.TypeForms.ToList();
            var projets = _context.Projets.ToList();
            var viewModel = new FormulaireViewModel
            {
                Formulaire = new Formulaire(),
                TypeForms = typeForms,
                Projets = projets

            };
            return View("Create", viewModel);
        }
        //public ActionResult Created()
        //{
        //    return View("List");
        //}
    }
}