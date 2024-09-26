namespace Clean_Architecture_Demo01.Infrastucture.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options){ }

        public DbSet<Blog> Blogs { get; set; }
    }
}
