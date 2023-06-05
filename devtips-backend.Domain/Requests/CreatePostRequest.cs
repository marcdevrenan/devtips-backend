using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Domain.Requests
{
    public class CreatePostRequest
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public Guid UserId { get; set; }
    }
}
