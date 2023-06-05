using devtips_backend.Domain.Requests;
using devtips_backend.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Domain.Interfaces
{
    public interface IPostService
    {
        Task<List<PostResponse>> GetAllPosts();
        Task<PostResponse> GetPostById(Guid id);
        Task<PostResponse> CreatePost(CreatePostRequest request);
        Task UpdatePost(Guid postId, UpdatePostRequest request);
        Task RatePost(Guid postId);
    }
}
