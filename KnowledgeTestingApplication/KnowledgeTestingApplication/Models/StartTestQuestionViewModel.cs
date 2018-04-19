using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTestingApplication.Models
{
    public class StartTestQuestionViewModel
    {
        public QuestionViewModel Question { get; set; }
        public QuestionPageInfo QuestionPageInfo { get; set; }
    }
}