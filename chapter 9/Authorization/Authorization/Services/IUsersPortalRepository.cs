using Authorization.Models;

namespace Authorization.Services
{
    public interface IUsersPortalRepository
    {
        List<UserPortal> UsersPortal { get; }
    }
}
