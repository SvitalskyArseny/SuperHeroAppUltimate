using System;

namespace SuperHeroProject.domain.utils
{
    public static class ExceptionHelper
    {
        private const string ErrorMessage = "Плохое соединение!";

        public static Result<T> TryCatch<T>(Func<Result<T>> func)
        {
            try
            {
                return func();
            }
            catch (Exception exp)
            {
                return Result.Fail<T>(ErrorMessage, exp);
            }
        }

        public static Result TryCatch(Action action)
        {
            try
            {
                action();
                return Result.Ok();
            }
            catch (Exception exp)
            {
                return Result.Fail(ErrorMessage, exp);
            }
        }
    }
}