using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeTestingApplication.Models
{
    public class QuestionPageInfo
    {
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public int TotalPages { get; set; }
    }
}