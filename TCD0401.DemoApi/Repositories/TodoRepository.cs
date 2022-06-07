using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

using TCD0401.DemoApi.Data;
using TCD0401.DemoApi.Models;
using TCD0401.DemoApi.Repositories.Interfaces;

namespace TCD0401.DemoApi.Repositories
{
  public class TodoRepository : ITodoRepository
  {
    private ApiDbContext _context;
    public TodoRepository(ApiDbContext context)
    {
      _context = context;
    }

    public async Task Create(ItemData item)
    {
      await _context.Items.AddAsync(item);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(ItemData item)
    {
      _context.Remove(item);
      await _context.SaveChangesAsync();
    }

    public async Task<List<ItemData>> GetAll()
    {
      return await _context.Items.ToListAsync();
    }

    public async Task<ItemData> GetById(int id)
    {
      return await _context.Items.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task Save()
    {
      await _context.SaveChangesAsync();
    }
  }
}
