using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTestingData.Models
{
    public class Question
    {
        public int Id { get; set; }

        [MaxLength(1000)]
        public string QuestionText { get; set; }

        public Answer CorrectAnswer { get; set; }
        public List<Answer> AnswerOptions { get; set; } = new List<Answer>(4);
    }
}
