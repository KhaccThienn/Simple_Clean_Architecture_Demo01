namespace Clean_Architecture_Demo01.Domain.Interfaces
{
    public interface IBlogRepository
    {
        Task<List<Blog>>    GetAllAsync();
        Task<Blog?>         GetByIdAsync(int id);
        Task<Blog>          CreateAsync(Blog entity);
        Task<int>           UpdateAsync(int id, Blog entity);
        Task<int>           DeleteAsync(int id);
    }
}
