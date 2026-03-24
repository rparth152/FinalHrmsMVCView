namespace HrmsMvc.services
{
     public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }
        public static ApiResponse<T> SuccessResponse(T data, string message = "Operation successful")
        {
            return new ApiResponse<T>
            {
                Success = true,
                Message = message,
                Data = data,
                Error = null
            };
        }
        public static ApiResponse<T> ErrorResponse(string errorMessage, string message = "Operation failed")
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Data = default,
                Error = errorMessage
            };
        }
    }
}
