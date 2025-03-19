﻿using CleanArchWithCQRS.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchWithCQRS.Infrastructure.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
