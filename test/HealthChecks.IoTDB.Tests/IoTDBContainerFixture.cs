using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;

namespace HealthChecks.IoTDB.Tests;

public class IoTDBContainerFixture : IAsyncLifetime
{
    private const string Image = "apache/iotdb:1.0.0-datanode";
    private const int IoTDBPort = 6667;

    public IContainer? Container { get; private set; }

    public string GetConnectionString()
    {
        if (Container is null)
        {
            throw new InvalidOperationException("The test container was not initialized.");
        }

        var host = Container.Hostname;
        var port = Container.GetMappedPublicPort(IoTDBPort);
        return $"host={host};port={port};user=root;password=root";
    }

    public async Task InitializeAsync() => Container = await CreateContainerAsync();

    public Task DisposeAsync() => Container?.DisposeAsync().AsTask() ?? Task.CompletedTask;

    private static async Task<IContainer> CreateContainerAsync()
    {
        var container = new ContainerBuilder(Image)
            .WithPortBinding(IoTDBPort, true)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilExternalTcpPortIsAvailable(IoTDBPort, _ => { }))
            .Build();

        await container.StartAsync();

        return container;
    }
}
