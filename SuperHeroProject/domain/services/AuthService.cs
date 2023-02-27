using System;
using SuperHeroProject.domain.model.user;
using SuperHeroProject.domain.repositories.interfaces;
using SuperHeroProject.domain.services.interfaces;
using SuperHeroProject.domain.utils;
using AuthState = SuperHeroProject.domain.model.enums.AuthState;

namespace SuperHeroProject.domain.services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }


        public Result LoginUser(string userName, string password)
        {
            try
            {
                var authState = authRepository.LoginUser(userName, password);
                return authState switch
                {
                    AuthState.InvalidPassword => Result.Fail("Неверный пароль"),
                    AuthState.NotRegisterYet => Result.Fail("Еще не зарегистрирован"),
                    _ => Result.Ok()
                };
            }
            catch (Exception exp)
            {
                return Result.Fail("Проблемы с соединением", exp);
            }
        }

        public Result RegisterUser(string userName, string password)
        {
            try
            {
                var userId = Utils.GetNewId();
                var user = new User(1, userId, userName, password, 0);
                var authState = authRepository.RegisterUser(user);
                return authState switch
                {
                    AuthState.LoggedAlready => Result.Fail("Уже есть такой аккаунт"),
                    _ => Result.Ok()
                };
            }
            catch (Exception exp)
            {
                return Result.Fail("Проблемы с соединением", exp);
            }
        }
    }
}