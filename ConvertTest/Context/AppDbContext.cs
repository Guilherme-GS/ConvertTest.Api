using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConvertTest.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ConvertTest.Context
{
    public class AppDbContext:DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Call> Calls { get; set; }
        public DbSet<Customer> Customer { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        //{
        //    //IConfiguration configuration = new ConfigurationBuilder()
        //    optionBuilder.UseSqlServer("");
        //}
    }
}
