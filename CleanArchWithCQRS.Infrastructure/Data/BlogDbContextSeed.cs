using Bogus;
using CleanArchWithCQRS.Domain.Entity;

namespace CleanArchWithCQRS.Infrastructure.Data
{
    public static class BlogDbContextSeed
    {
        public static void SeedData(BlogDbContext context)
        {
            if (!context.Blogs.Any()) // Avoid seeding if there's already data
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