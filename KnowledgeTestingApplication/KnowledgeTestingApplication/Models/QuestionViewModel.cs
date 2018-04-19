using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTestingApplication.Models
{
    public class QuestionViewModel
    {
        public string QuestionText { get; set; }
        public Dictionary<int, string> AnswerOptions { get; set; }
        public List<string> RightAnswer { get; set; }
        public List<string> UserChoice { get; set; }
        public bool Checkboxed { get; set; }
    }
}