using MediatR;

namespace CleanArchWithCQRS.Application.Blogs.Queries
{
    public class GetBlogQuery : IRequest<List<BlogVm>>
    {
    }
    //public record GetBlogQuery : IRequest<List<BlogVm>>
    //{
    //}
}
