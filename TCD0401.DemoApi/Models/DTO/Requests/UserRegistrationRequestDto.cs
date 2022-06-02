using System.ComponentModel.DataAnnotations;

namespace TCD0401.DemoApi.Models.DTO.Requests
{
  public class UserRegistrationRequestDto
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
  }
}
