using AutoMapper;
using MediatR;
using PostLand.Domain.Contracts;
using PostLand.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Features.Posts.Queries.GetPostList
{
    public class GetPostsListQueryHandler : IRequestHandler<GetPostsListQuery, List<PostListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPostsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<PostListDto>> Handle(GetPostsListQuery request, CancellationToken cancellationToken)
        {
           var allPosts = await _unitOfWork.Repository<Post>().GetAllAsync();

            return _mapper.Map<List<PostListDto>>(allPosts);
        }
    }
}
