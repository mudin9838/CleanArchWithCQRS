using MediatR;

namespace CleanArchWithCQRS.Application.Blogs.Queries.GetBlogsById
{
    public class GetBlogsByIdQuery : IRequest<BlogVm>
    {
        public int BlogId { get; set; }   //what we need to send as query parameter
    }
}
