using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Data
{
    public class ApplicationDbContext :DbContext
    {
        private readonly IConfiguration _config;
       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                string connstr = _config["ConnectionStrings:DefaultConnection"].ToString();
                optionsBuilder.UseSqlServer(connstr);
            }
        }
        public DbSet<Student> Student { get; set; }
    }
}
