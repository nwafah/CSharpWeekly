using System;
using System.Collections.Generic;
using System.Text;

namespace ResultPattern.Model
{
    public record Error(string code, string description, ErrorType type);

    public enum ErrorType
    {
        Validation = 0,
        Conflict = 1,
        NotFound = 2,
        Unauthorized = 3,
        Forbidden = 4,
        InternalServerError = 5
    }

    public class Result<T> where T : class 
    {
        public bool IsSuccess { get; set; }
        public T? Value { get; set; }
        public Error? Error { get; set; }

        private Result(T value)
        {
            Value = value;
            IsSuccess = true;
        }

        private Result(Error error)
        {
            Error = error;
            IsSuccess = false;
        }

        public static Result<T> Success(T value) => new(value);
        public static Result<T> Failure(Error error) => new(error);

    }
}
