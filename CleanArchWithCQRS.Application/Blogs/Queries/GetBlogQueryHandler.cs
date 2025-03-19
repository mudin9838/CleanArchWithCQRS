using CleanArchWithCQRS.Domain.Repository;
using MediatR;

namespace CleanArchWithCQRS.Application.Blogs.Queries
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        private readonly IBlogRepository blogRepository;

        public GetBlogQueryHandler(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }
        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await blogRepository.GetAllBlogAsync();
            return blogs.Select(b => new BlogVm
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                Author = b.Author
            }).ToList();
        }

    }
}