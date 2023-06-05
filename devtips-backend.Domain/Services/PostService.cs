using devtips_backend.Domain.Interfaces;
using devtips_backend.Domain.Requests;
using devtips_backend.Domain.Responses;
using devtips_backend.Infrastructure.Interfaces;
using devtips_backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<PostResponse>> GetAllPosts()
        {
            var posts = await _postRepository.GetAllAsync();
            return posts.Select(p => new PostResponse(p)).ToList();
        }

        public async Task<PostResponse> GetPostById(Guid id)
        {
            var post = await _postRepository.GetByIdAsync(id) ?? throw new Exception("Post not found");
            return new PostResponse(post);
        }

        public async Task<PostResponse> CreatePost(CreatePostRequest request)
        {
            var post = new Post
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Content = request.Content,
                PublishDate = DateTime.UtcNow,
                UserId = request.UserId
            };

            await _postRepository.CreateAsync(post);
            return new PostResponse(post);
        }

        public async Task UpdatePost(Guid postId, UpdatePostRequest request)
        {
            var oldPost = await _postRepository.GetByIdAsync(postId) ?? throw new Exception("Post not found");
            oldPost.Title = request.Title;
            oldPost.Content = request.Content;
            oldPost.Rate = request.Rate;

            await _postRepository.UpdateAsync(oldPost);
        }

        public async Task RatePost(Guid postId)
        {
            var post = await _postRepository.GetByIdAsync(postId) ?? throw new Exception("Post not found");
            post.Rate++;
            await _postRepository.UpdateAsync(post);
        }
    }
}
