namespace Lennt.Dto
{
    public class ResponseModel<T> : IResponse<T>
    {
        public string Error { get; set; }
        public T Data { get; set; }
    }
}
