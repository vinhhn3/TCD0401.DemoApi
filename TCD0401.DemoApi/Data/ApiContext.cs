using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using TCD0401.DemoApi.Models;

namespace TCD0401.DemoApi.Data
{
  public class ApiDbContext : IdentityDbContext
  {
    public DbSet<ItemData> Items { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }

  }
}
