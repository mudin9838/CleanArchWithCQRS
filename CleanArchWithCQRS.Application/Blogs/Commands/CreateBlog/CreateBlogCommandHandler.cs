using AutoMapper;
using CleanArchWithCQRS.Application.Blogs.Queries;
using CleanArchWithCQRS.Domain.Entity;
using CleanArchWithCQRS.Domain.Repository;
using MediatR;

namespace CleanArchWithCQRS.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public IBlogRepository BlogRepository { get; }

        public async Task<BlogVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogEntity = new Blog() { Author = request.Author, Description = request.Description, Name = request.Name };

            var result = await _blogRepository.AddBlogAsync(blogEntity);
            return _mapper.Map<BlogVm>(result); //since our return type expect BlogVm, we converted blog to BlogVm


        }
    }
}
