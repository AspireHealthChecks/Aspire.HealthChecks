## HealthChecks.NTPServer

Package provides an `IHealthCheck` implementation for NTP servers, verifying time synchronization.

### Nuget

[![Nuget](https://img.shields.io/nuget/v/DotNetDiag.HealthChecks.NTPServer)](https://www.nuget.org/packages/DotNetDiag.HealthChecks.NTPServer)

### Usage

```csharp
services.AddHealthChecks()
    .AddNTPServer(options =>
    {
        options.NtpServer = "pool.ntp.org";
        options.ToleranceSeconds = 10.0;
    });
```
