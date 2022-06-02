using System.Collections.Generic;

namespace TCD0401.DemoApi.Domain
{
  public class AutResult
  {
    public string Token { get; set; }
    public bool Result { get; set; }
    public List<string> Errors { get; set; }
  }
}
