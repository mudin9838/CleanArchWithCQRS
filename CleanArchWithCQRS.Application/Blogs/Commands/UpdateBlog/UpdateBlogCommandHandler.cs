using CleanArchWithCQRS.Domain.Entity;
using CleanArchWithCQRS.Domain.Repository;
using MediatR;

namespace CleanArchWithCQRS.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int> //our request UpdateBlogCommand & our return type/response is int
    {
        private readonly IBlogRepository _blogRepository;
        public UpdateBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public IBlogRepository BlogRepository { get; }

        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var updateBlogEntity = new Blog()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
            };
            return await _blogRepository.UpdateBlogAsync(request.Id, updateBlogEntity);

        }
    }
}
