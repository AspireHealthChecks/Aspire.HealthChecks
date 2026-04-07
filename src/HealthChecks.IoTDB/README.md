## HealthChecks.IoTDB

Package provides an `IHealthCheck` implementation for Apache IoTDB using `Apache.IoTDB.Data`.

### Nuget

[![Nuget](https://img.shields.io/nuget/v/DotNetDiag.HealthChecks.IoTDB)](https://www.nuget.org/packages/DotNetDiag.HealthChecks.IoTDB)

### Usage

```csharp
services.AddHealthChecks()
    .AddIoTDB("host=localhost;port=6667;user=root;password=root");
```
