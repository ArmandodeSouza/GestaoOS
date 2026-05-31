using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOS.Domain {
    public class Result {
        public bool Success { get; private set; }
        public string Error { get; private set; }

        protected Result(bool success, string error) {
            Success = success;
            Error = error;
        }

        public static Result Ok() {
            return new Result(true, null);
        }

        public static Result Fail(string error) {
            return new Result(false, error);
        }
    }
    public class Result<T> : Result {
        public T Value { get; private set; }

        private Result(bool success, T value, string error)
            : base(success, error) {
            Value = value;
        }

        public static Result<T> Ok(T value) {
            return new Result<T>(true, value, null);
        }

        public static new Result<T> Fail(string error) {
            return new Result<T>(false, default(T), error);
        }
    }

}
