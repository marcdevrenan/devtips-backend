using devtips_backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Domain.Responses
{
    public class PostResponse
    {
        public PostResponse(Post post)
        {
            Id = post.Id;
            Title = post.Title;
            Content = post.Content;
            Rate = post.Rate;
            PublishDate = post.PublishDate;
            UserId = post.UserId;
            Author = post.User?.Name ?? "";
        }

        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int Rate { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid UserId { get; set; }
        public string Author { get; set; } = null!;
    }
}
