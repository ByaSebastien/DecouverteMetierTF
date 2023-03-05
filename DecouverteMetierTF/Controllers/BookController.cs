using DecouverteMetierTF.Models;
using DecouverteMetierTF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DecouverteMetierTF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookRepository _bookRepository;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpPost]
        public IActionResult Insert(BookDTO b)
        {
            try
            {
                _bookRepository.Add(new Book(b));
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
                _bookRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Update(Book b)
        {
            try
            {
                _bookRepository.Update(b);
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
                IEnumerable<Book> books = _bookRepository.GetAll();
                return Ok(books);
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
                Book book = _bookRepository.GetById(id);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("favorite/{userId}/{bookId}")]
        public IActionResult AddFavorite(int userId,int bookId)
        {
            try
            {
                _bookRepository.AddFavorite(userId, bookId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("favorite/{userId}/{bookId}")]
        public IActionResult DeleteFavorite(int userId, int bookId)
        {
            try
            {
                _bookRepository.DeleteFavorite(userId, bookId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("favorite/{userId}")]
        public IActionResult GetAllFavorite(int userId)
        {
            try
            {
                IEnumerable<Book> books = _bookRepository.GetAllFavorite(userId);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
