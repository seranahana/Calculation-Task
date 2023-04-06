namespace CalcTask.WebAPI.Library.Providers
{
    public class DefaultMessagesProvider : IMessagesProvider
    {
        private const string InternalServerErrorMessage = "An internal server error occurred. If the problem persists, please contact software developer.";
        private const string InvalidResultErrorMessage = "The caluculation result exceeds the limits or not a number.";

        public string GetInternalServerErrorMessage()
        {
            return InternalServerErrorMessage;
        }

        public string GetInvalidResultErrorMessage()
        {
            return InvalidResultErrorMessage;
        }
    }
}
