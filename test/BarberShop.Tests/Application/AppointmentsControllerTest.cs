using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace BarberShop.Tests.Application
{
  public class AppointmentsControllerTest
  {
    private HttpClient client;
    private TestServer server;

    [Fact]
    public async Task Lists_Appointments()
    {
            
      server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
      client = server.CreateClient();

      var response = await client.GetAsync("/api/appointments");
      response.EnsureSuccessStatusCode();

      var responseString = await response.Content.ReadAsStringAsync();

      responseString.Should().StartWith("[{\"ID\":");
    }

  }
}