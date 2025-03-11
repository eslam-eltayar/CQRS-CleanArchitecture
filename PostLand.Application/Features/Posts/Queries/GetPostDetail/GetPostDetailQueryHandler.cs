using AutoMapper;
using MediatR;
using PostLand.Domain.Contracts;
using PostLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Features.Posts.Queries.GetPostDetail
{
    public class GetPostDetailQueryHandler : IRequestHandler<GetPostDetailQuery, PostDetailDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPostDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PostDetailDto> Handle(GetPostDetailQuery request, CancellationToken cancellationToken)
        {
            var post = await _unitOfWork.Repository<Post>().GetByIdAsync(request.Id);

            return _mapper.Map<PostDetailDto>(post);
        }
    }
}
