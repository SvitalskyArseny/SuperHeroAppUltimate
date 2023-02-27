using System;
using static System.String;

namespace SuperHeroProject.domain.utils
{
    public class Result
    {
        public bool Success { get; }

        public bool Failure => !Success;

        public string ErrorMessage { get; }

        public Exception Exception { get; }

        protected Result(bool success, string errorMessage, Exception exception = null)
        {
            Success = success;
            ErrorMessage = errorMessage;
            Exception = exception;
        }

        public static Result Fail(string errorMessage, Exception exception = null)
        {
            return new Result(false, errorMessage, exception);
        }

        public static Result<T> Fail<T>(string errorMessage, Exception exception = null)
        {
            return new Result<T>(default(T), false, errorMessage, exception);
        }

        public static Result Ok()
        {
            return new Result(true, Empty);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, Empty);
        }
    }

    public class Result<T> : Result
    {
        public T Value { get; }


        protected internal Result(T value, bool success, string errorMessage, Exception exception = null)
            : base(success, errorMessage, exception)
        {
            Value = value;
        }
    }
}