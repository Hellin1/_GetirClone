namespace GetirClone.Application.Responses
{
    public class Response : IResponse
    {
        public Response()
        {

        }

        public Response(ResponseType responseType)
        {
            ResponseType = responseType;
        }

        public Response(ResponseType responseType, string message)
        {
            ResponseType = responseType;
            Message = message;
        }

        public Response(ResponseType responseType, List<CustomValidationError> errors)
        {
            ResponseType = responseType;
            ValidationErrors = errors;
        }


        public string Message { get; set; }

        public ResponseType ResponseType { get; set; }

        public List<CustomValidationError> ValidationErrors { get; set; }

    }

    public enum ResponseType
    {
        Success,
        ValidationError,
        NotFound,
    }
}
