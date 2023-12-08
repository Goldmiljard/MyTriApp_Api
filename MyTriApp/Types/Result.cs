using System.Diagnostics.CodeAnalysis;

namespace MyTriApp.Types
{
    public class Result
    {
        public bool Success { get; set; }
        public string Error { get; set; }

        protected Result(bool success, string error)
        {
            Success = success;
            Error = error;
        }

        public static Result Fail(string error)
        {
            return new Result(false, error);
        }

        public static Result<T> Fail<T>(string error)
        {
            return new Result<T>(default, false, error);
        }
        public static Result Ok()
        {
            return new Result(true, string.Empty);
        }
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, string.Empty);
        }
    }

    public class Result<T> : Result
    {
        private T _value;
        public T Value
        {
            get
            {
                return _value;
            }
            [param: AllowNull]
            private set { _value = value; }
        }
        protected internal Result([AllowNull] T value, bool success, string error)
        : base(success, error)
        {
            Value = value;
        }
    }
}
