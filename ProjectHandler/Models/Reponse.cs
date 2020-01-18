using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHandler.Models
{
    public class Reponse
    {
        public int Id { get; set; }
        public int Groupe { get; set; }
        public string Valeur { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string CreePar { get; set; }
        public DateTime CreeLe { get; set; }
    }
}