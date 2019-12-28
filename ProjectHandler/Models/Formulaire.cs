using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHandler.Models
{
    public class Formulaire
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Type Formulaire")]
        public int TypeFormId { get; set; }
        public TypeForm TypeForm { get; set; }
        [Display(Name = "Projet")]
        public int ProjetId { get; set; }
        public Projet Projet { get; set; }
        public string CreePar { get; set; }
        public DateTime CreeLe { get; set; }
    }
}