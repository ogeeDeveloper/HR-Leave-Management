using HrLeaveManagement.Api.Middlewares;
using HRLeaveManagement.Application;
using HRLeaveManagement.Infrastructure;
using HRLeaveManagement.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.\
builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddAPersistenceServices(builder.Configuration);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("all");

app.UseAuthorization();

app.MapControllers();

app.Run();
