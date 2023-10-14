using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTestingData.Models
{
    public class User
    {

        public Guid Id { get; set; }
        public string PasswordHash { get; set; }

        [MaxLength(100)]
        public string UserName { get; set; }
        public List<Test> UserTests { get; set; } = new List<Test>();

        [MaxLength(100)]
        public string Role { get; set; }
    }
}
