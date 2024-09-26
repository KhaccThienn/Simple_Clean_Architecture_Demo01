namespace Clean_Architecture_Demo01.Infrastucture.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _context;

        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<Blog> CreateAsync(Blog entity)
        {
            await _context.Blogs.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.Blogs
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await _context.Blogs.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Blog entity)
        {
            return await _context.Blogs
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(setter => setter
                    .SetProperty(b => b.Name, entity.Name)
                    .SetProperty(b => b.Description, entity.Description)
                    .SetProperty(b => b.Author, entity.Author)
                    .SetProperty(b => b.ImageUrl, entity.ImageUrl)
                );
        }
    }
}
