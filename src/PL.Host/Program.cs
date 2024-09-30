using Microsoft.EntityFrameworkCore;
using PL.Api;
using PL.BW;
using PL.Engine;
using Serilog;


var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) =>
{
    lc.ReadFrom.Configuration(ctx.Configuration);
});
builder.Services.ConfigureMasstransit(builder.Configuration);
builder.Services.AddEngine(ConfigureDbContext);
builder.Services.AddPLControllers();
var app = builder.Build();
app.UseSerilogRequestLogging();
app.UsePLGqlControllers();
app.Run();
return;

void ConfigureDbContext(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseNpgsql(builder!.Configuration.GetConnectionString("postgresConnection"),
        b =>
        {
            b.MigrationsAssembly(typeof(Program).Assembly.GetName().Name);
            b.MigrationsHistoryTable("__EFMigrationsHistory", "povorotlite");
        });
}