using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTestingData.Models;

namespace UserTestingData.DataAccess
{
	public class TestingAppDbContext : DbContext
	{

        public TestingAppDbContext(DbContextOptions options):base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Test> Tests { get; set; }

        public  DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }




    }
}
