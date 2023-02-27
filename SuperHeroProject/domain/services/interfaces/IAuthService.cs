using SuperHeroProject.domain.utils;

namespace SuperHeroProject.domain.services.interfaces
{
    public interface IAuthService
    {
        public Result LoginUser(string userName, string password);
        public Result RegisterUser(string userName, string password);
    }
}