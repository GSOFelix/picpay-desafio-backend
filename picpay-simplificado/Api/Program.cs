using Infra.Ext.Extensions;
using Infra.Ext.Middleware;
using SQLitePCL;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddInfraestructure();

Batteries.Init();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.UseHttpsRedirection();


app.Run();


