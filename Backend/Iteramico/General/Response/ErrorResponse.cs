namespace General.Response
{
    public class ErrorResponse<T>(string errorCode, T? data = null, string message = "") : Response<T>(data, message) where T : class
    {
        public string ErrorCode { get; set; } = errorCode;
    }
}