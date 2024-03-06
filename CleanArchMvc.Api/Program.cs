using Microsoft.OpenApi.Models;
using CleanArchMvc.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureApi(builder.Configuration);
builder.Services.AddInfrastructureJwt(builder.Configuration);
builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();