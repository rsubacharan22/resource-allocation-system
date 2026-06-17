using System.Security.Claims;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var username =
            context.User?.Identity?.Name ?? "Anonymous";

        var role =
            context.User?.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Role)
                ?.Value ?? "NoRole";

        var method = context.Request.Method;

        var endpoint = context.Request.Path;

        await _next(context);

        var statusCode = context.Response.StatusCode;
        var dbContext =
    context.RequestServices
        .GetRequiredService<AppDbContext>();

var auditLog = new AuditLog
{
    Username = username,
    Role = role,
    Method = method,
    Endpoint = endpoint,
    StatusCode = statusCode,
    Timestamp = DateTime.UtcNow
};

dbContext.AuditLogs.Add(auditLog);

await dbContext.SaveChangesAsync();

        Console.WriteLine(
            $"[{DateTime.Now}] " +
            $"User:{username} " +
            $"Role:{role} " +
            $"Method:{method} " +
            $"Endpoint:{endpoint} " +
            $"Status:{statusCode}");
    }
}