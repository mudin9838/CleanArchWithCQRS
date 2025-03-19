using AutoMapper;
using CleanArchWithCQRS.Domain.Repository;
using MediatR;

namespace CleanArchWithCQRS.Application.Blogs.Queries
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAllBlogAsync();
            var blogList = _mapper.Map<List<BlogVm>>(blogs);
            return blogList;
        }

    }
}