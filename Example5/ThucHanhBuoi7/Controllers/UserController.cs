using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ThucHanhBuoi7.Models;

public class UserController : Controller
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index() => View();

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _context.Users.ToListAsync();
        return Json(users);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        if (ModelState.IsValid)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Json(user);
        }
        return BadRequest(ModelState);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] User user)
    {
        if (ModelState.IsValid)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return Json(user);
        }
        return BadRequest(ModelState);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
        return NotFound();
    }
}
