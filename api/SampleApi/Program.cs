var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// The Angular build is copied into wwwroot at deploy time, so one site serves both the page and the API.
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/outreach", () => StripeData.GetAll());
app.MapGet("/api/health", () => Results.Ok(new { status = "ok" }));

app.Run();

public record StripeItem(Guid Id, int Number, string Name, string Detail, string Status);

public static class StripeData
{
    public static IReadOnlyList<StripeItem> GetAll() =>
    [
        new(Guid.Parse("11111111-1111-1111-1111-111111111111"), 7001, "Morning round", "City centre", "Completed"),
        new(Guid.Parse("22222222-2222-2222-2222-222222222222"), 7002, "Severe weather check", "Riverside", "Planned"),
        new(Guid.Parse("33333333-3333-3333-3333-333333333333"), 7003, "Evening round", "Station", "Completed"),
    ];
}
