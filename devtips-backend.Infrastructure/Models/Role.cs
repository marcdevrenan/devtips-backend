using devtips_backend.Infrastructure.Enums;

namespace devtips_backend.Infrastructure.Models
{
    public class Role : BaseModel
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public RoleType Type { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
