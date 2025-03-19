using MediatR;

namespace CleanArchWithCQRS.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommand : IRequest<int> //we are returning whatever updated id so we return int
    {
        //we get those properties from the user,& we've to update to db
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
