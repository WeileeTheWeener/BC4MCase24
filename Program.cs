WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();
WebApplication app = builder.Build();

app.MapGet("/", () => "{\"msg\":\"BC4M\"}");
app.MapHealthChecks("/health");

app.MapPost("/", async (HttpRequest request) =>
{
    using var reader = new StreamReader(request.Body);
    var requestBody = await reader.ReadToEndAsync();

    return Results.Text(requestBody);
});

app.Run();
