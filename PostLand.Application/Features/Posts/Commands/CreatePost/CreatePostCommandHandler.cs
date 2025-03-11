using FluentValidation;
using MediatR;
using PostLand.Domain.Contracts;
using PostLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            CreateCommandValidator validator = new CreateCommandValidator();

            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                throw new ValidationException("Post is not valid");
            }

            var post = new Post
            {
                Title = request.Title,
                Content = request.Content,
                CategoryId = request.CategoryId
                
            };

            _unitOfWork.Repository<Post>().Add(post);

            await _unitOfWork.CompleteAsync();

            return post.Id;
        }
    }
}
