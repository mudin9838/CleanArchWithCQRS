using CleanArchWithCQRS.Domain.Entity;

namespace CleanArchWithCQRS.Domain.Repository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogAsync();
        Task<Blog> GetByIdAsync(int id);
        Task<Blog> AddBlogAsync(Blog blog);
        Task<int> UpdateBlogAsync(int id, Blog blog);
        Task<int> DeleteBlogAsync(int id);

    }
}
