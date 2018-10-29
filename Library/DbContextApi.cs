using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library
{
    public class DbContextApi : DbContext
    {
        public DbContextApi(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
    }
}
