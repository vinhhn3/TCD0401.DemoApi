using System.ComponentModel.DataAnnotations;

namespace TCD0401.DemoApi.Models
{
  public class ItemData
  {
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Details { get; set; }
    public bool Done { get; set; }

  }

}
