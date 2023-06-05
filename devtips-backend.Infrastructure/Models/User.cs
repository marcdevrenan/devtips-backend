namespace devtips_backend.Infrastructure.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public required byte[] PasswordHash { get; set; } = null!;
        public required byte[] PasswordSalt { get; set; } = null!;
        public Guid? RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
    }
}
