using CleanArch.Application.Authentication.Abstractions;
using CleanArch.Application.Authentication.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}