using Microsoft.AspNetCore.Authentication.Cookies;
using TicTacToe.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromDays(4);
        options.SlidingExpiration = true;
    });

builder.Services.AddSingleton<IUsersService, UsersService>();
builder.Services.AddSingleton<IPendingPlayers, PendingPlayers>();
builder.Services.AddSingleton<IGameSessionService, GameSessionService>();
builder.Services.AddTransient<IEngineService, EngineService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
