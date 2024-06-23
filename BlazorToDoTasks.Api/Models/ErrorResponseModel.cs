namespace BlazorToDoTasks.Api.Models
{
    public class ErrorResponseModel
    {
        public ErrorResponseModel()
        {

        }

        public ErrorResponseModel(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

        public string PropertyName { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
   
        public IList<ErrorResponseModel> ToList()
        {
            return
            [
                new ErrorResponseModel(PropertyName, ErrorMessage),
            ];
        }
    }
}
