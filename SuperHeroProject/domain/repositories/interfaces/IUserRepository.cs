using SuperHeroProject.domain.model.user;

namespace SuperHeroProject.domain.repositories.interfaces
{
    public interface IUserRepository
    {
        public void AddUser(User user);
        public User GetUser();
        public string GetUserId();
        public bool isLogged();
        public void logOut();
    }
}