namespace Lennt.Dto
{
    public interface IResponse<T>
    {
        string Error { get; set; }
        T Data { get; set; }
    }
}
