using FluentValidation;
using Lxf.Support.BuildingBlocks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 

namespace LxF.Support;
public sealed class GlobalExceptionHandler(RequestDelegate next)
{
    private readonly RequestDelegate _next = next ?? throw new ArgumentNullException(nameof(next));

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (ValidationException exception)
        {
            var errros = exception.Errors.GroupBy(t => t.PropertyName).ToDictionary(g => g.Key, g => g.Select(t => t.ErrorMessage).ToArray());

            await Results.ValidationProblem(errros).ExecuteAsync(httpContext);
        }
        catch (BadRequestException exception)
        {
            var problem = new ProblemDetails { Status = StatusCodes.Status400BadRequest, Detail = exception.Message };

            await Results.BadRequest(problem).ExecuteAsync(httpContext);
        }
        catch (ElementNotFoundException exception)
        {
            var problem = new ProblemDetails { Status = StatusCodes.Status404NotFound, Detail = exception.Message};

            await Results.NotFound(problem).ExecuteAsync(httpContext);
        }
        catch (EntityNotFoundException exception)
        {
            var problem = new ProblemDetails { Status = StatusCodes.Status404NotFound, Detail = exception.Message };

            await Results.NotFound(problem).ExecuteAsync(httpContext);
        }
        catch (DuplicateRecordException exception)
        {
            var problem = new ProblemDetails { Status = StatusCodes.Status409Conflict, Detail = exception.Message };

            await Results.Conflict(problem).ExecuteAsync(httpContext);
        }
        catch (DbUpdateException exception)
        {
            if (exception.InnerException != null && (exception.InnerException.Message.Contains("UNIQUE KEY") || exception.InnerException.Message.Contains("IX_")))
            {
                var problem = new ProblemDetails
                {
                    Status = StatusCodes.Status409Conflict,
                    Detail = "Uno o mas campos ya existen en uno o mas registros."
                };
                await Results.Conflict(problem).ExecuteAsync(httpContext);
            }
            else
            {
                // Si es otro error de base de datos no esperado
                var problem = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Detail = "Ocurrió un error inesperado al intentar guardar en la base de datos."
                };
                await Results.Problem(problem).ExecuteAsync(httpContext);
            }
        }

    }   

}

public static class GlobalExceptionHandlerExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<GlobalExceptionHandler>();
    }
}
