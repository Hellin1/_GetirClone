namespace GetirClone.Application.Responses
{
    public class ErrorModel
    {
        public ErrorModel()
        {

        }

        public ErrorModel(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
