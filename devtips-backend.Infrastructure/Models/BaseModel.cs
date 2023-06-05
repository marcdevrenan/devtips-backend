using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Infrastructure.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
