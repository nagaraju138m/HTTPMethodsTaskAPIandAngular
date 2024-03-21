using Microsoft.AspNetCore.Mvc;
using TaskHTTPMethods.Modals;

namespace TaskHTTPMethods.Controllers
{
    public class CategoryController : Controller
    {
        private readonly TaskDbContext context;

        public CategoryController(TaskDbContext taskDbContext)
        {
            this.context = taskDbContext;
        }

        [HttpGet("getCategories")]
        public IActionResult getCategories()
        {
            List<Category> categories = new List<Category>();
            categories = context.Categories.ToList();
            return Ok(categories);
        }

        [HttpPost("PostCategories")]
        public async Task<IActionResult> postCategory(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return Ok(category);
        }

        //[HttpPut("updateCat")]
        //public async Task<IActionResult> updateCat(Category category)
        //{
        //    Category cat = await context.Categories.FindAsync(category.CategoryId);
        //    if(cat == null)
        //    {
        //        return BadRequest("not found");
        //    }
        //    cat.ca
        //}

    }
}
