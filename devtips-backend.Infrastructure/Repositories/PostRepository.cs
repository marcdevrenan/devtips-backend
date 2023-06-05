using devtips_backend.Infrastructure.Contexts;
using devtips_backend.Infrastructure.Interfaces;
using devtips_backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;

        public PostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetAllAsync()
        {
            //return await _context.Posts.ToListAsync();
            //return await _context.Posts
            //    .Include(p => p.User).ToListAsync();
            return await _context.Posts.Join(_context.Users,
                p => p.UserId,
                u => u.Id,
                (p, u) => new Post
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    Rate = p.Rate,
                    PublishDate = p.PublishDate,
                    UserId = p.UserId,
                    User = u
                }).ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(Guid id)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
            //return await _context.Posts
            //    .Include(p => p.User)
            //    .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Post?> GetByTitleAsync(string title)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.Title.ToLower() == title.ToLower());
        }

        public async Task<Post?> GetByPublishDateAsync(DateTime publishDate)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.PublishDate == publishDate);
        }

        public async Task<Post> CreateAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }
    }
}
