namespace MiddlewareComponent.Components
{
public class AgeMiddleware
{
    private readonly RequestDelegate _next;

    public AgeMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var age = string.IsNullOrEmpty(context.Request.Query["age"]) ? 0 : Convert.ToInt32(context.Request.Query["age"]);
        if (age < 18)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Age is invalid");
        }
        else
        {
            await _next.Invoke(context);
        }
    }
}
}
