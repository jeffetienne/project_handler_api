using ProjectHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHandler.ViewModels
{
    public class QuestionViewModel
    {
        public IEnumerable<Component> Components { get; set; }
        public IEnumerable<TypeDonnee> TypeDonnees { get; set; }
        public IEnumerable<Formulaire> Formulaires { get; set; }
        public Question Question { get; set; }
        public DynamicReference DynamicReference { get; set; }
    }
}