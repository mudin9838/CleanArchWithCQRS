using CleanArchWithCQRS.Infrastructure.Data;

namespace CleanArchWithCQRS.Infrastructure.Repository
{
    public class DataSeeder : IDataSeeder
    {
        private readonly BlogDbContext _context;

        public DataSeeder(BlogDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            BlogDbContextSeed.SeedData(_context);
        }
    }
}