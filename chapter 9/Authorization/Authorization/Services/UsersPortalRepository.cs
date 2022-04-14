using Authorization.Models;

namespace Authorization.Services
{
    public class UsersPortalRepository : IUsersPortalRepository
    {
        private List<UserPortal> data;
        public UsersPortalRepository()
        {
            data = new List<UserPortal>()
            {
                new UserPortal() { Id = 1, UserName = "Admin", Password = "123"  },
                new UserPortal() { Id = 2, UserName = "Guest", Password = "321" }
            };
        }
        List<UserPortal> IUsersPortalRepository.UsersPortal => data;
    }
}
