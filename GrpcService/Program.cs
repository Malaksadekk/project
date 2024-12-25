using GrpcService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting(); // Enables endpoint routing

app.UseEndpoints(endpoints =>
{
    // Map gRPC services here
    endpoints.MapGrpcService<GreeterService>();
    endpoints.MapGrpcService<ProductService>();

    // Optional: Map a default endpoint
    endpoints.MapGet("/", context =>
    {
        return context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
    });
});

app.Run();
