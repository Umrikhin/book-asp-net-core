namespace LifeTimeService.Services
{
    public class GuidService : IGuidService
    {
        private Guid _value;
        public GuidService()
        {
            _value = Guid.NewGuid();
        }
        public Guid Value
        {
            get { return _value; }
        }
    }
}
