namespace GoldenEye.Core.Objects.Requests
{
    public class EmptyRequest: IEmptyRequest
    {
        public static EmptyRequest Create()
        {
            return new EmptyRequest();
        }
    }
}
