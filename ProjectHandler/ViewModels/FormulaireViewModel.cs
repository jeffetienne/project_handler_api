using ProjectHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHandler.ViewModels
{
    public class FormulaireViewModel
    {
        public IEnumerable<TypeForm> TypeForms { get; set; }
        public IEnumerable<Projet> Projets { get; set; }
        public Formulaire Formulaire { get; set; }
    }
}