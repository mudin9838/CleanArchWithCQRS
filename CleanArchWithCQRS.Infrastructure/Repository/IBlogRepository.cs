using CleanArchWithCQRS.Domain.Entity;
using CleanArchWithCQRS.Domain.Repository;
using CleanArchWithCQRS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchWithCQRS.Infrastructure.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _context;

        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<Blog> AddBlogAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<Int32> DeleteBlogAsync(Int32 id)
        {
            return await _context.Blogs.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllBlogAsync()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(Int32 id)
        {
            return await _context.Blogs.AsNoTracking().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Int32> UpdateBlogAsync(Int32 id, Blog blog)
        {
            return await _context.Blogs
            .Where(model => model.Id == id).ExecuteUpdateAsync(setters => setters
            .SetProperty(m => m.Id, blog.Id)
            .SetProperty(m => m.Name, blog.Name)
            .SetProperty(m => m.Description, blog.Description)
            .SetProperty(m => m.Author, blog.Author)
            );

        }
    }
}
