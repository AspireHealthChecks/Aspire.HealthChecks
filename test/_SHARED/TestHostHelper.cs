using Microsoft.Extensions.Hosting;

public static class TestHostHelper
{
    public static IHost Build(Action<IWebHostBuilder> configureWebHost)
    {
        return new HostBuilder()
            .ConfigureWebHost(configureWebHost)
            .Build();
    }
}
