namespace GetirClone.Application.Responses
{
    public class ResultModel<T> : ResultModel
    {
        public ResultModel()
        {

        }
        public ResultModel(T value)
        {
            IsSuccessful = true;
            Result = value;
        }

        public T Result { get; set; }
    }
    public class ResultModel
    {
        public static ResultModel Successfull()
        {
            return new ResultModel
            {
                IsSuccessful = true,
            };
        }
        public static ResultModel Error(string code, string message)
        {
            return new ResultModel
            {
                IsSuccessful = false,
                Errors = new List<ErrorModel>
                {
                    new ErrorModel(code, message)
                }
            };
        }
        public bool IsSuccessful { get; set; }
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
        public void AddError(string errorCode, string errorMessage)
        {
            Errors.Add(new ErrorModel
            {
                ErrorCode = errorCode,
                ErrorMessage = errorMessage
            });
        }
    }
}