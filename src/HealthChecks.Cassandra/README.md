## HealthChecks.Cassandra

Package provides an `IHealthCheck` implementation for Cassandra databases using the `CassandraCSharpDriver`.

### Nuget

[![Nuget](https://img.shields.io/nuget/v/DotNetDiag.HealthChecks.Cassandra)](https://www.nuget.org/packages/DotNetDiag.HealthChecks.Cassandra)

### Usage

```csharp
services.AddHealthChecks()
    .AddCassandra(sp => sp.GetRequiredService<ICluster>());
```
