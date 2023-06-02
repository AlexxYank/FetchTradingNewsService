using AVATrade.API.Extensions;
using AVATrade.Infrastructure.Extensions;
using AVATrade.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureInfrastructureServices();

builder.Services.ConfigureApplicationServices();

builder.Services.ConfigureSwagger();

builder.Services.AddControllers();

var app = builder.Build();

#if DEBUG
app.UseSwagger();
app.UseSwaggerUI();
#endif

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

