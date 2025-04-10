﻿using Bogus;
using CleanArchWithCQRS.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchWithCQRS.Infrastructure.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }

        public static void SeedData(BlogDbContext context)
        {
            if (!context.Blogs.Any()) // Check if data already exists
            {
                var faker = new Faker();

                var blogs = new List<Blog>();

                // Generate 10 random blogs using Bogus
                for (int i = 0; i < 10; i++)
                {
                    blogs.Add(new Blog
                    {
                        Name = faker.Company.CompanyName(),
                        Description = faker.Lorem.Paragraph(),
                        Author = faker.Name.FullName()
                    });
                }

                // Insert them into the database
                context.Blogs.AddRange(blogs);
                context.SaveChanges();
            }
        }
    }
}
