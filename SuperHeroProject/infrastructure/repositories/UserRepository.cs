using Microsoft.EntityFrameworkCore;
using SuperHeroProject.domain.model.user;
using SuperHeroProject.domain.repositories.interfaces;
using SuperHeroProject.infrastructure.db;

namespace SuperHeroProject.infrastructure.repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDatabase db;

        public UserRepository(AppDatabase db)
        {
            this.db = db;
        }

        public void AddUser(User user)
        {
            db.Database.EnsureCreated();

            logOut();

            db.User.Add(user);
            db.SaveChanges();
        }

        public User GetUser()
        {
            db.User.Load();
            return db.User.Find(1);
        }

        public string GetUserId()
        {
            var user = GetUser();
            return user != null ? user.UserId : "";
        }

        public bool isLogged()
        {
            return GetUser() != null;
        }

        public void logOut()
        {
            var userToRemove = GetUser();

            if (userToRemove == null) return;
            db.User.Remove(userToRemove);
            db.SaveChanges();
        }
    }
}