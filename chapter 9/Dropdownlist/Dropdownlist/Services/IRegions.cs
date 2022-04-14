using Dropdownlist.Models;

namespace Dropdownlist.Services
{
    public interface IRegions
    {
        List<Land> countrys { get; }
        List<City> towns { get; }
    }
}
