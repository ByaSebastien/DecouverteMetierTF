using DecouverteMetierTF.Models;
using DecouverteMetierTF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DecouverteMetierTF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryRepository _categoryRepository;
        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpPost]
        public IActionResult Insert(CategoryDTO c)
        {
            try
            {
                _categoryRepository.Add(new Category(c));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Update(Category c)
        {
            try
            {
                _categoryRepository.Update(c);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<Category> categories = _categoryRepository.GetAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Category category = _categoryRepository.GetById(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
