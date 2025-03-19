using AutoMapper;
using CleanArchWithCQRS.Domain.Repository;
using MediatR;

namespace CleanArchWithCQRS.Application.Blogs.Queries.GetBlogsById
{
    public class GetBlogsByIdHandler : IRequestHandler<GetBlogsByIdQuery, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogsByIdHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public IBlogRepository BlogRepository { get; }

        public async Task<BlogVm> Handle(GetBlogsByIdQuery request, CancellationToken cancellationToken)
        {
            //we are calling repository

            var blog = await _blogRepository.GetByIdAsync(request.BlogId);
            return _mapper.Map<BlogVm>(blog);

        }
    }
}
