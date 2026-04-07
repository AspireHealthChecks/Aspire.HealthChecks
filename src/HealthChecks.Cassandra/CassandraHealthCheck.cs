using Cassandra;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecks.Cassandra;

/// <summary>
/// A health check for Cassandra databases.
/// </summary>
public class CassandraHealthCheck : IHealthCheck
{
    private readonly ICluster _cluster;
    private readonly CassandraHealthCheckOptions? _options;

    public CassandraHealthCheck(ICluster cluster, CassandraHealthCheckOptions? options = null)
    {
        _cluster = cluster;
        _options = options;
    }

    /// <inheritdoc />
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            ISession session = _options?.Keyspace is { } keyspace
                ? await _cluster.ConnectAsync(keyspace).ConfigureAwait(false)
                : await _cluster.ConnectAsync().ConfigureAwait(false);

            return session is not null
                ? HealthCheckResult.Healthy()
                : new HealthCheckResult(context.Registration.FailureStatus, description: "Could not connect to Cassandra.");
        }
        catch (Exception ex)
        {
            return new HealthCheckResult(context.Registration.FailureStatus, description: ex.Message, exception: ex);
        }
    }
}
