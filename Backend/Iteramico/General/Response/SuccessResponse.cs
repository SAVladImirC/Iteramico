namespace General.Response
{
    public class SuccessResponse<T>(T data) : Response<T> where T : class
    {
        public T Data { get; set; } = data;
    }
}