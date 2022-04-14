using System.Diagnostics;

namespace MonitorApp.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private Timer? _timer;
        IMonitorPanel _monitor;
        public TimedHostedService(IMonitorPanel monitor)
        {
            _monitor = monitor;
        }
        public Task StartAsync(CancellationToken stoppingToken)
        {
            //Задаем выполнение через каждую минуту
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }
        private void DoWork(object? state)
        {
            var prc = Process.GetCurrentProcess();
            _monitor.Add(new Models.Indication() { TimePoint = DateTime.Now, Memory = prc.WorkingSet64 });
        }
        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
