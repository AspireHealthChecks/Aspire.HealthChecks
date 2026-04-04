using HealthChecks.UI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace HealthChecks.UI.Tests;

public class UpdateConfigurationTests
{
    [Fact]
    public async Task update_healthchecks_uris_when_configuration_exists()
    {
        var endpointName = "endpoint1";
        var endpointUri = "http://server/sample";
        var updatedEndpointUri = $"{endpointUri}2";

        Func<string, ManualResetEventSlim, IHost> getHost = (uri, hostReset) =>
            TestHostHelper.Build(webHostBuilder => webHostBuilder
                .ConfigureServices(services =>
                {
                    services
                    .AddRouting()
                    .AddHealthChecksUI(setup => setup.AddHealthCheckEndpoint(endpointName, uri))
                    .AddSqliteStorage("Data Source = sqlite-updates.db");
                })
                .Configure(app =>
                {
                    app.UseRouting();
                    app.UseEndpoints(setup => setup.MapHealthChecksUI());

                    var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
                    lifetime.ApplicationStarted.Register(() => hostReset.Set());
                }));

        var hostReset = new ManualResetEventSlim(false);
        using var host1 = getHost(endpointUri, hostReset);
        using var server1 = new TestServer(host1.Services);
        hostReset.Wait();

        var context = host1.Services.GetRequiredService<HealthChecksDb>();
        var configurations = await context.Configurations.ToListAsync();

        configurations[0].Name.ShouldBe(endpointName);
        configurations[0].Uri.ShouldBe(endpointUri);

        hostReset = new ManualResetEventSlim(false);
        using var host2 = getHost(updatedEndpointUri, hostReset);
        using var server2 = new TestServer(host2.Services);
        hostReset.Wait();

        context = host2.Services.GetRequiredService<HealthChecksDb>();
        configurations = await context.Configurations.ToListAsync();

        configurations[0].Name.ShouldBe(endpointName);
        configurations[0].Uri.ShouldBe(updatedEndpointUri);
    }
}
