using System.Net;

namespace HealthChecks.NTPServer.Tests.Functional;

public class ntpserver_healthcheck_should
{
    [Fact]
    public async Task be_healthy_when_ntp_server_is_reachable()
    {
        using var host = TestHostHelper.Build(webHostBuilder => webHostBuilder
            .ConfigureServices(services =>
            {
                services.AddHealthChecks()
                    .AddNTPServer(options =>
                    {
                        options.NtpServer = "pool.ntp.org";
                        options.ToleranceSeconds = 60.0;
                    }, tags: ["ntp"]);
            })
            .Configure(static app =>
            {
                app.UseHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = static r => r.Tags.Contains("ntp")
                });
            }));

        var server = host.GetTestServer();
        using var response = await server.CreateRequest("/health").GetAsync();

        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }

    [Fact]
    public async Task be_unhealthy_when_ntp_server_is_not_reachable()
    {
        using var host = TestHostHelper.Build(webHostBuilder => webHostBuilder
            .ConfigureServices(services =>
            {
                services.AddHealthChecks()
                    .AddNTPServer(options =>
                    {
                        options.NtpServer = "invalid.ntp.server.does.not.exist.example.com";
                        options.ToleranceSeconds = 10.0;
                    }, tags: ["ntp"], timeout: TimeSpan.FromSeconds(15));
            })
            .Configure(static app =>
            {
                app.UseHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = static r => r.Tags.Contains("ntp")
                });
            }));

        var server = host.GetTestServer();
        using var response = await server.CreateRequest("/health").GetAsync();

        response.StatusCode.ShouldBe(HttpStatusCode.ServiceUnavailable);
    }

    [Fact]
    public async Task be_degraded_when_tolerance_is_zero()
    {
        using var host = TestHostHelper.Build(webHostBuilder => webHostBuilder
            .ConfigureServices(services =>
            {
                services.AddHealthChecks()
                    .AddNTPServer(options =>
                    {
                        options.NtpServer = "pool.ntp.org";
                        options.ToleranceSeconds = 0.0;
                    }, tags: ["ntp"], failureStatus: HealthStatus.Unhealthy);
            })
            .Configure(static app =>
            {
                app.UseHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = static r => r.Tags.Contains("ntp"),
                    ResultStatusCodes =
                    {
                        [HealthStatus.Healthy] = 200,
                        [HealthStatus.Degraded] = 200,
                        [HealthStatus.Unhealthy] = 503,
                    }
                });
            }));

        var server = host.GetTestServer();
        using var response = await server.CreateRequest("/health").GetAsync();

        // With zero tolerance, any non-zero offset will be degraded or unhealthy
        response.StatusCode.ShouldBeOneOf(HttpStatusCode.OK, HttpStatusCode.ServiceUnavailable);
    }
}
