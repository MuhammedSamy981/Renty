using Microsoft.AspNetCore.Mvc.Controllers;
using Renty.Domain.Interfaces;
using Renty.Infrastructure.Data;
using Renty.Domain.Entities;

public class AuditLogMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<AuditLogMiddleware> _logger;

    public AuditLogMiddleware(RequestDelegate next, ILogger<AuditLogMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context,ApplicationDbContext dbContext)
    {
        var request = context.Request;
        var auditLog = new
        { 
            UserName = context?.User.Identity!.Name?? "Anonymous",
            Path = request.Path,
            Method = request.Method,
            TimeStamp = DateTime.UtcNow,
            IPAddress = context?.Connection.RemoteIpAddress?.ToString()
        };

        _logger.LogInformation("Audit Log: {@AuditLog}", auditLog);
        var auditLogToAdd=new AuditLog
        { 
            UserName = auditLog.UserName,
            Path = auditLog.Path,
            Method = auditLog.Method,
            TimeStamp = auditLog.TimeStamp,
            IPAddress = auditLog.IPAddress!
        };
        dbContext.AuditLogs.Add(auditLogToAdd);
       await dbContext.SaveChangesAsync();

        await _next(context!);
    }
}





/*
public class AuditSaveChangesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        var context = eventData.Context;
        var entries = context.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added || e.State == EntityState.Deleted);

        foreach (var entry in entries)
        {
            // Capture details like entry.Entity, entry.State, etc.
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
*/

/*services.AddDbContext<ApplicationDbContext>((sp, options) =>
{
    options.UseSqlServer("YourConnectionString");
    options.AddInterceptors(new AuditSaveChangesInterceptor());
});*/
