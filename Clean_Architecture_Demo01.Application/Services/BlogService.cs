namespace Clean_Architecture_Demo01.Application.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;

        public BlogService(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task<Blog> CreateAsync(Blog entity)
        {
            return _repository.CreateAsync(entity);
        }

        public Task<int> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<List<Blog>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Blog?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<int> UpdateAsync(int id, Blog entity)
        {
            return _repository.UpdateAsync(id, entity);
        }
    }
}
