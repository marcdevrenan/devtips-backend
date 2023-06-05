using devtips_backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Infrastructure.Interfaces
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Task<Post?> GetByTitleAsync(string title);
        Task<Post?> GetByPublishDateAsync(DateTime publishDate);
        Task<Post> CreateAsync(Post post);
        Task UpdateAsync(Post post);
    }
}
