using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BottomsSupAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Tokens> Tokens { get; set; }
        //  public DbSet<Comment> Comments { get; set; }



        //public ApplicationDbContext()
        //    : base("DefaultConnection")
        //{
        //}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
