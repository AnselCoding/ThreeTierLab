using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ThreeTierLab.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // 捕捉異常
            var exception = context.Exception;

            // 進行日誌記錄或通知操作
            string exceptionType = exception.GetType().Name;
            string errorMessage = exception.Message;
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("An exception occurred:");
            Console.WriteLine($"{exceptionType}, {errorMessage}");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");

            // 返回自定義的錯誤響應
            var result = new ObjectResult(new { ErrorMessage = "An error occurred." })
            {
                StatusCode = 500, // 500 Internal Server Error
            };

            context.Result = result;
            context.ExceptionHandled = true;
        }
    }

}
