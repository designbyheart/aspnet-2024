using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySQLDemo.Data;
using MySQLDemo.Models;

namespace MySQLDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetCSharpCornerArticles()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetCSharpCornerArticle(int id)
        {
            var article = await _context.Users.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return article;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostCSharpCornerArticle(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("User", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCSharpCornerArticle(int id, User article)
        {
            if (id != article.Id)
            {
                return BadRequest();
            }

            _context.Entry(article).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CSharpCornerArticleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCSharpCornerArticle(int id)
        {
            var article = await _context.Users.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Users.Remove(article);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CSharpCornerArticleExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
