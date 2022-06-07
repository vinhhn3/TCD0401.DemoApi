using TCD0401.DemoApi.Services.IServices;

namespace TCD0401.DemoApi.Services
{
  public class Calculator : ICalculator
  {
    public Calculator()
    {

    }

    public int Add(int a, int b)
    {
      return a + b;
    }
  }
}
