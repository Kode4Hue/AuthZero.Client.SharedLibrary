namespace AuthZero.Client.SharedLibrary.Common.ErrorHandling
{
    public class ErrorResponse
    {
#nullable disable
        public int StatusCode { get; set; }
        public string Error { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
#nullable enable
    }
}
