using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SecurityTests.Services
{
	public class ChangingHealthStates : IHealthCheck
	{
		public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
		{
			return (DateTime.Now.Second % 3) switch
			{
				0 => Task.FromResult(HealthCheckResult.Healthy()),
				1 => Task.FromResult(HealthCheckResult.Degraded()),
				_ => Task.FromResult(HealthCheckResult.Unhealthy()),
			};
		}
	}
}