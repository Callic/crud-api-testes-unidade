
namespace Bravi.Application.Responses
{
    public class GenericResponse<T> : GenericResponseBase<GenericResponse<T>>
    {
        public T? Data{ get; set; }
    }
}
