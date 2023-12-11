namespace GetirClone.Application.Responses
{
    public class Response<T> : Response, IResponse<T>
    {
        public T Data { get; set; }

        public Response() : base()
        {

        }

        public Response(ResponseType responseType, string message) : base(responseType, message)
        {

        }

        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }

        public Response(T data, List<CustomValidationError> errors) : base(ResponseType.ValidationError, errors)
        {
            Data = data;
        }

        public Response(ResponseType responseType, List<CustomValidationError> errors) : base(ResponseType.ValidationError, errors)
        {

        }
    }
}
