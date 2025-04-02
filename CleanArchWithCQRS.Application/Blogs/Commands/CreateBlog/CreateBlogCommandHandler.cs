using AutoMapper;
using Bogus;
using CleanArchWithCQRS.Application.Blogs.Queries.GetBlogs;
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
            // If you want to use Bogus to generate random data when no data is provided, for instance
            var faker = new Faker();

            // If no Author or Name is provided in the request, we generate random values
            var blogEntity = new Blog
            {
                Name = string.IsNullOrWhiteSpace(request.Name) ? faker.Company.CompanyName() : request.Name,
                Description = string.IsNullOrWhiteSpace(request.Description) ? faker.Lorem.Paragraph() : request.Description,
                Author = string.IsNullOrWhiteSpace(request.Author) ? faker.Name.FullName() : request.Author,
            };

            // Save to the repository
            var result = await _blogRepository.AddBlogAsync(blogEntity);

            // Map the result to a BlogVm (ViewModel)
            return _mapper.Map<BlogVm>(result);
        }
    }
}
