namespace Clean_Architecture_Demo01.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _service;
        public BlogController(IBlogService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _service.GetAllAsync();
            return Ok(blogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _service.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            var createdBlog = await _service.CreateAsync(blog);
            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Blog blog)
        {
            int existingBlog = await _service.UpdateAsync(id, blog);
            if (existingBlog == 0)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetById), new { id = blog.Id }, blog);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int existingBlog = await _service.DeleteAsync(id);
            if (existingBlog == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}