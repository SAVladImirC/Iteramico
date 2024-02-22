using General.Request;
using General.Response;

namespace General.Service
{
    public interface IGeneralService<T> where T : class
    {
        public Task<Response<T>> Create(IGeneralRequest request);
    }
}