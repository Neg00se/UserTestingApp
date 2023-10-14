using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTestingData.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [MaxLength(500)]
        public string AnswerText { get; set; }
    }
}
