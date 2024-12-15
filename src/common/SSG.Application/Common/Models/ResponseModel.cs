namespace SSG.Application.Models
{
    public class ResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<string> ValidationErrors { get; set; }
        public static ResponseModel<T> Success(T value) => new() { IsSuccess = true, Value = value };
        public static ResponseModel<T> Error(string errorMessage) => new() { IsSuccess = false, ErrorMessage = errorMessage };
        public static ResponseModel<T> ValidationError(IEnumerable<string> errorMessage,T value) => new() { IsSuccess = false, ValidationErrors = errorMessage,Value = value };
    }
}