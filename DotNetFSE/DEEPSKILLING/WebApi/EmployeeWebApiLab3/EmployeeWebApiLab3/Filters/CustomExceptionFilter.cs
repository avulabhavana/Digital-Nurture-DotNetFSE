using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeWebApiLab3.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string folder = @"C:\Temp";
            Directory.CreateDirectory(folder);

            string filePath = Path.Combine(folder, "ExceptionLog.txt");

            File.AppendAllText(
                filePath,
                $"[{DateTime.Now}] {context.Exception.Message}{Environment.NewLine}"
            );

            context.Result = new ObjectResult(new
            {
                Status = 500,
                Message = context.Exception.Message
            })
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}