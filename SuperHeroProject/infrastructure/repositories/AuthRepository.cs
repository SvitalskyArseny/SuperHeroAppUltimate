using Firebase.Database;
using Firebase.Database.Query;
using SuperHeroProject.domain.model.enums;
using SuperHeroProject.domain.model.user;
using SuperHeroProject.domain.repositories.interfaces;

namespace SuperHeroProject.infrastructure.repositories
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AuthRepository : IAuthRepository
    {
        private readonly FirebaseClient firebase = new(CustomHeroRepository.BaseUrl);

        private const string Users = "users";

        private readonly UserRepository db;

        public AuthRepository(UserRepository db)
        {
            this.db = db;
        }

        public AuthState LoginUser(string userName, string password)
        {
            var task = firebase
                .Child(Users)
                .Child(userName)
                .OnceSingleAsync<User>();
            task.Wait();
            if (task.Result == null)
            {
                return AuthState.NotRegisterYet;
            }

            var validPassword = task.Result.Password;
            if (validPassword != password) return AuthState.InvalidPassword;
            db.AddUser(task.Result);
            return AuthState.Success;
        }

        public AuthState RegisterUser(User user)
        {
            var task = firebase
                .Child(Users)
                .Child(user.UserName)
                .OnceSingleAsync<User>();
            task.Wait();
            if (task.Result != null)
            {
                return AuthState.LoggedAlready;
            }

            firebase
                .Child(Users)
                .Child(user.UserName)
                .PutAsync(user).Wait();
            db.AddUser(user);
            return AuthState.Success;
        }
    }
}