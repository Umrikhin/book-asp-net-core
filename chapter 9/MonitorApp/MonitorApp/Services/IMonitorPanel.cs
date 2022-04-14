using MonitorApp.Models;

namespace MonitorApp.Services
{
    public interface IMonitorPanel
    {
        IEnumerable<Indication> GetAll();
        int Add(Indication newIndication);
    }
}
