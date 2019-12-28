using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectHandler.Models
{
    public class Projet
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        public Domaine Domaine { get; set; }
        [Display(Name = "Domaine")]
        public int DomaineId { get; set; }
        public string CreePar { get; set; }
        public DateTime CreeLe { get; set; }
    }
}