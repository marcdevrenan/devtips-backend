using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Domain.Requests
{
    public class UpdatePostRequest
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int Rate { get; set; }
    }
}
