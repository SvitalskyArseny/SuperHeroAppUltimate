using SuperHeroProject.domain.model.enums;
using SuperHeroProject.domain.model.user;

namespace SuperHeroProject.domain.repositories.interfaces
{
    public interface IAuthRepository
    {
        public AuthState LoginUser(string userName, string password);
        public AuthState RegisterUser(User user);
    }
}