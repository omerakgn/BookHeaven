using BookHeaven.Core.Features.Commands.Comment.CreateComments;
using BookHeaven.Core.Features.Commands.Comment.DeleteComment;
using BookHeaven.Core.Features.Commands.Comment.UpdateComment;
using BookHeaven.Core.Features.Queries.GetAllComments;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookHeaven.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Yorumları Getir (Daha önce yazmıştık)
        [HttpGet("[action]/{bookId}")]
        public async Task<ActionResult<GetAllCommentsQueryResponse>> GetComments(int bookId)
        {
            var query = new GetAllCommentsQueryRequest
            {
                BookId = bookId,
               
            };

            var response = await _mediator.Send(query);
            return Ok(response);
        }

        // Yorum Ekle
        [HttpPost("[action]")]
        public async Task<ActionResult<CreateCommentCommandResponse>> CreateComment([FromBody] CreateCommentCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // Yorum Güncelle
        [HttpPut("[action]/{commentId}")]
        public async Task<ActionResult<UpdateCommentCommandResponse>> UpdateComment(int commentId, [FromBody] UpdateCommentCommandRequest request)
        {
            request.CommentId = commentId;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // Yorum Sil
        [HttpDelete("[action]/{commentId}")]
        public async Task<ActionResult<DeleteCommentCommandResponse>> DeleteComment(int commentId)
        {
            var request = new DeleteCommentCommandRequest { CommentId = commentId };
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }

}
