using CleanArchWithCQRS.Application.Blogs.Commands.CreateBlog;
using CleanArchWithCQRS.Application.Blogs.Queries.GetBlogs;
using CleanArchWithCQRS.Application.Blogs.Queries.GetBlogsById;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchWithCQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var blogs = await Mediator.Send(new GetBlogQuery()); //Send asynchronously send requesr i.eGetBlogQuery
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var blog = await Mediator.Send(new GetBlogsByIdQuery() { BlogId = id });
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBlogCommand command)
        {
            var createdBlog = await Mediator.Send(command);
            return Ok(createdBlog);
        }
    }
}
