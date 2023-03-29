using AuthZero.Client.SharedLibrary.Common.ErrorHandling;

namespace AuthZero.Client.SharedLibrary.Common.General
{
    public class NoContentResult
    {
        internal NoContentResult(bool succeeded, ErrorResponse? errorResponse)
        {
            Succeeded = succeeded;
            ErrorResponse = errorResponse;
        }

        public bool Succeeded { get; init; }

        public ErrorResponse? ErrorResponse { get; init; }

        public static NoContentResult Success()
        {
            return new NoContentResult(true, null);
        }

        public static NoContentResult Failure(ErrorResponse errorResponse)
        {
            return new NoContentResult(false, errorResponse);
        }
    }
}
