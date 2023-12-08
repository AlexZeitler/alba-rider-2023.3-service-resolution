using Alba;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit.Abstractions;

namespace ServiceResolutionRepro.IntegrationTests;

public class When_resolving_iid_generator_from_host_services : IAsyncLifetime
{
  private IIdGenerator? _idGenerator;
  private IAlbaHost? _host;


  public async Task InitializeAsync()
  {
    var builder = ConfigureHost.GetHostBuilder();
    _host = await builder.StartAlbaAsync();

    _idGenerator = _host.Services.GetService<IIdGenerator>();
  }

  [Fact]
  public void should_not_be_null() => _idGenerator.ShouldNotBeNull();


  public async Task DisposeAsync() => await _host.DisposeAsync();
}
