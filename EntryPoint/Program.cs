using API.Extensions;
using Infrastructure.Extensions;
using Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureInfrastructureServices();

builder.Services.ConfigureApplicationServices();

builder.Services.ConfigureSwagger();

builder.Services.AddControllers();

var app = builder.Build();

app.UseDatabaseMigration();

#if DEBUG
app.UseSwagger();
app.UseSwaggerUI();
#endif

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

