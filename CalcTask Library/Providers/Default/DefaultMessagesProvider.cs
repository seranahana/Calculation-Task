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

        public string GetMissingParameterErrorMessage(Params missingParam)
        {
            string missingParamName = Constants.ParamNames[missingParam];

            if (missingParamName is not null)
                return $"The {missingParamName} parameter is missing.";

            return "Some of parameters are missing";
        }
    }
}
