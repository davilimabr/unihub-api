using System.Net;
using System.Text.Json;
using Unihub.Dominio.Comum.Excecoes;

namespace Unihub.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            string message = "Ocorreu um erro interno no servidor.";

            switch (exception)
            {
                case ArgumentException: statusCode = HttpStatusCode.InternalServerError;
                    message = exception.Message;
                    break;

                case RecursoNaoEncontradoException: statusCode = HttpStatusCode.NotFound;
                    message = exception.Message;
                    break;
            }
            
            context.Response.StatusCode = (int)statusCode;

            var result = JsonSerializer.Serialize(new { Erro = message });

            return context.Response.WriteAsync(result);
        }
    }

    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
