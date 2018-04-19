using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.DomainModels
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int TestId { get; set; }
        public string QuestionText { get; set; }
        public Dictionary<int, string> AnswerOptions { get; set; }
        public List<string> RightAnswer { get; set; }
        public List<string> UserChoice { get; set; }
        public bool Checkboxed { get; set; }
    }
}
