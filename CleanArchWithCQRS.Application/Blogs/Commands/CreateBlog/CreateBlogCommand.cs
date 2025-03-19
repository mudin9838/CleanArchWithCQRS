using CleanArchWithCQRS.Application.Blogs.Queries.GetBlogs;
using MediatR;

namespace CleanArchWithCQRS.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommand : IRequest<BlogVm>  //we can pass what ever we want based on return type
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
