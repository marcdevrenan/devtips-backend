namespace devtips_backend.Infrastructure.Models
{
    public class Post : BaseModel
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public int Rate { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
