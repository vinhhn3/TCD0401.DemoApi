using System.Collections.Generic;
using System.Threading.Tasks;

using TCD0401.DemoApi.Models;

namespace TCD0401.DemoApi.Repositories.Interfaces
{
  public interface ITodoRepository
  {
    Task<List<ItemData>> GetAll();
    Task<ItemData> GetById(int id);
    Task Create(ItemData item);
    Task Delete(ItemData item);
    Task Save();
  }
}
