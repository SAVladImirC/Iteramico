namespace General.Response
{
    public class Response<T>(T? data = null, string message = "") where T : class
    {
        public T? Data { get; set; } = data;
        public string Message { get; set; } = message;
    }
}