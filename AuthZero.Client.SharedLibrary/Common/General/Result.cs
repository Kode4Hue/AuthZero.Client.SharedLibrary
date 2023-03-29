using AuthZero.Client.SharedLibrary.Common.ErrorHandling;

namespace AuthZero.Client.SharedLibrary.Common.General
{
    public class Result<T> where T : class
    {
        internal Result(bool succeeded, ErrorResponse? errorResponse, T? content = null)
        {
            Succeeded = succeeded;
            ErrorResponse = errorResponse;
            Content = content;
        }

        public bool Succeeded { get; init; }

        public ErrorResponse? ErrorResponse { get; init; }

        public T? Content { get; set; }

        public static Result<T> Success(T? content = null)
        {
            return new Result<T>(true, null, content);
        }

        public static Result<T> Failure(ErrorResponse errorResponse)
        {
            return new Result<T>(false, errorResponse);
        }
    }
}
