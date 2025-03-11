using MediatR;
using PostLand.Domain.Contracts;
using PostLand.Domain.Entities;

namespace PostLand.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.Repository<Post>().GetByIdAsync(request.Id);

            if (post == null)
            {
                throw new Exception("Post Not Founded");
            }

            post.Title = request.Title;
            post.Content = request.Content;
            post.CategoryId = request.CategoryId;

            _unitOfWork.Repository<Post>().Update(post);

            await _unitOfWork.CompleteAsync(cancellationToken);
  
        }
    }
}
