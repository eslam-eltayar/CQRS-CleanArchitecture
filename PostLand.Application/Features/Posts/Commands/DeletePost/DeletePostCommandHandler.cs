using MediatR;
using PostLand.Domain.Contracts;
using PostLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Features.Posts.Commands.DeletePost
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.Repository<Post>().GetByIdAsync(request.Id);

            if (post == null)
            {
                throw new Exception("Post Not Founded");
            }

            _unitOfWork.Repository<Post>().Delete(post);

            await _unitOfWork.CompleteAsync();
        }
    }
}
