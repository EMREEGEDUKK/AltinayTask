using AltınayTask;
using AltınayTask.Models;

public class JobService : IHostedService, IDisposable
{
    private readonly IServiceProvider _services;
    private readonly Timer _timer;

    public JobService(IServiceProvider services)
    {
        _services = services;
        _timer = new Timer(MethodB, null, TimeSpan.Zero, TimeSpan.FromHours(6));
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private void MethodB(object state)
    {
        using (var scope = _services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var jobObjects = dbContext.JobObject.ToList();

            foreach (var jobObject in jobObjects)
            {

                jobObject.attrA *= 2;

                SaveToDatabase(jobObject, dbContext);
                Utility.LogDbUpdate(jobObject.id,jobObject.attrA);
            }
        }
    }

    private void SaveToDatabase(JobObject jobObject, AppDbContext dbContext)
    {

        dbContext.JobObject.Update(jobObject);
        dbContext.SaveChanges();
    }



    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
