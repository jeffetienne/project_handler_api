﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectHandler.Models.DTOs
{
    public class DynamicReferenceByQuestionDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Texte { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public string CreePar { get; set; }
        public DateTime CreeLe { get; set; }
    }
}