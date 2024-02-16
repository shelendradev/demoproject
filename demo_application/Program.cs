
using demo_application.Constants;
using DemoBAL;
using DemoBAL.interfaces;
using DemoDAL;
using DemoDAL.DBContext;
using DemoDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File(Constants.LOG_FILE_PATH).CreateLogger();

// Add services to the container.
builder.Services.AddControllers();

builder.Host.UseSerilog();

builder.Services.AddDbContext<DefaultDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(Constants.CONNECTION_STRING_KEY));
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Implementing Dependency Injection
builder.Services.AddScoped<IDemoAPIDAL, DemoAPIDAL>();
builder.Services.AddScoped<IDemoAPIBAL, DemoAPIBAL>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//else
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors((settings) => settings.AllowAnyHeader().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSerilogRequestLogging();

app.Run();
