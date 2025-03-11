using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }  
        public int CategoryId { get; set; }
    }
}
