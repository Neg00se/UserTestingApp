using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTestingData.Models
{
    public class Test
    {

        public int Id { get; set; }
        public Guid UserId { get; set; }
        List<Question> Questions { get; set; } = new List<Question>();
        public bool Completed { get; set; } = false;
        public float? Mark { get; set; }
    }
}
