using MonitorApp.Models;

namespace MonitorApp.Services
{
    public class MonitorPanel : IMonitorPanel
    {
        private List<Indication> _rows = new List<Indication>();
        public int Add(Indication newIndication)
        {
            if (_rows.Count == 0)
            {
                newIndication.Id = 1;
            }
            else
            {
                newIndication.Id = _rows.Max(p => p.Id) + 1;
            }
            _rows.Add(newIndication);
            return newIndication.Id;
        }
        public IEnumerable<Indication> GetAll()
        {
            return _rows;
        }
    }
}
