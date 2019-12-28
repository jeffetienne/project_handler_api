using ProjectHandler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHandler.ViewModels
{
    public class ProjetViewModel
    {
        public IEnumerable<Domaine> Domaines { get; set; }
        public Projet Projet { get; set; }
    }
}