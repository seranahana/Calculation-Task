namespace CalcTask.WebAPI.Library.Providers
{
    public interface IMessagesProvider
    {
        string GetInternalServerErrorMessage();
        string GetInvalidResultErrorMessage();
    }
}
