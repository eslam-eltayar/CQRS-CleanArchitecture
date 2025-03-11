using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostLand.Application.Features.Posts.Commands.CreatePost;
using PostLand.Application.Features.Posts.Commands.DeletePost;
using PostLand.Application.Features.Posts.Commands.UpdatePost;
using PostLand.Application.Features.Posts.Queries.GetPostDetail;
using PostLand.Application.Features.Posts.Queries.GetPostList;

namespace PostLand.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<PostListDto>>> GetPosts()
        {
            var posts = await _mediator.Send(new GetPostsListQuery());

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDetailDto>> GetPost(int id)
        {
            var post = await _mediator.Send(new GetPostDetailQuery { Id = id });
            return Ok(post);
        }

        [HttpPost("")]
        public async Task<ActionResult<int>> CreatePost([FromBody] CreatePostCommand command)
        {
            var postId = await _mediator.Send(command);
            return Ok(postId);
        }

        [HttpPut("")]
        public async Task<ActionResult> UpdatePost([FromBody] UpdatePostCommand command)
        { 
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("")]
        public async Task<ActionResult> DeletePost(int id)
        {
            await _mediator.Send(new DeletePostCommand { Id = id });
            return NoContent();
        }
    }
}
