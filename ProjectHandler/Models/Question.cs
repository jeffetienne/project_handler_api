using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHandler.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FormulaireId { get; set; }
        public Formulaire Formulaire { get; set; }
        public string Message { get; set; }
        public int TypeDonneeId { get; set; }
        public TypeDonnee TypeDonnee { get; set; }
        public int? Minimum { get; set; }
        public int? Maximum { get; set; }
        public int ComponentId { get; set; }
        public Component Component { get; set; }
        public bool Required { get; set; }
        public string CreePar { get; set; }
        public DateTime CreeLe { get; set; }
    }
}