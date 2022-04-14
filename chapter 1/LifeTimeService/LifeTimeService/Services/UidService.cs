namespace LifeTimeService.Services
{
    public class UidService
    {
        protected internal IGuidService GUID { get; }
        public UidService(IGuidService _GUID)
        {
            GUID = _GUID;
        }
    }
}
