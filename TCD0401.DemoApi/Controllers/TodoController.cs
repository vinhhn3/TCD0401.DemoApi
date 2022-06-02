using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;

using TCD0401.DemoApi.Data;
using TCD0401.DemoApi.Models;

namespace TCD0401.DemoApi.Controllers
{
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  [Route("api/[controller]")]
  [ApiController]
  public class TodoController : ControllerBase
  {
    private readonly ApiDbContext _context;

    public TodoController(ApiDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public ActionResult GetItems()
    {
      var items = _context.Items.ToList();
      return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItem(int id)
    {
      var item = await _context.Items.FirstOrDefaultAsync(z => z.Id == id);

      if (item == null)
        return NotFound();

      return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem(ItemData data)
    {
      if (ModelState.IsValid)
      {
        await _context.Items.AddAsync(data);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetItem", new { data.Id }, data);
      }

      //return new JsonResult("Something Went wrong") { StatusCode = 400 };
      return BadRequest("Something went wrong");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, ItemData item)
    {
      if (id != item.Id)
        return BadRequest();

      var existItem = await _context.Items.FirstOrDefaultAsync(z => z.Id == id);

      if (existItem == null)
        return NotFound();

      existItem.Title = item.Title;
      existItem.Details = item.Details;

      await _context.SaveChangesAsync();

      // Following up the REST standart on update we need to return NoContent
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
      var existItem = await _context.Items.FirstOrDefaultAsync(z => z.Id == id);

      if (existItem == null)
        return NotFound();

      _context.Items.Remove(existItem);
      await _context.SaveChangesAsync();

      return Ok(existItem);
    }
  }
}
