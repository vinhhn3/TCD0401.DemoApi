using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using TCD0401.DemoApi.Data;
using TCD0401.DemoApi.Models;
using TCD0401.DemoApi.Repositories.Interfaces;
using TCD0401.DemoApi.Services.IServices;

namespace TCD0401.DemoApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TodoController : ControllerBase
  {
    private ITodoRepository _todoRepos;
    private ICalculator _calculator;

    public TodoController(ApiDbContext context, ITodoRepository todoRepository, ICalculator calculator)
    {
      _todoRepos = todoRepository;
      _calculator = calculator;
    }

    [HttpGet]
    public async Task<ActionResult> GetItems()
    {
      var result = _calculator.Add(1, 2);
      var items = await _todoRepos.GetAll();
      return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetItem(int id)
    {
      var item = await _todoRepos.GetById(id);

      if (item == null)
        return NotFound();

      return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem(ItemData data)
    {
      if (ModelState.IsValid)
      {
        await _todoRepos.Create(data);

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

      var existItem = await _todoRepos.GetById(id);

      if (existItem == null)
        return NotFound();

      existItem.Title = item.Title;
      existItem.Details = item.Details;

      await _todoRepos.Save();

      // Following up the REST standart on update we need to return NoContent
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
      var existItem = await _todoRepos.GetById(id);

      if (existItem == null)
        return NotFound();

      await _todoRepos.Delete(existItem);

      return Ok(existItem);
    }
  }
}
