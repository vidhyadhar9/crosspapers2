using Microsoft.AspNetCore.Localization;
using Microsoft.Data.SqlClient;
using StudentsManagementservice;
using StudentsqlRepo;
using System.Data;
using System.Globalization;
using System.Runtime.InteropServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServices,Services>();
builder.Services.AddScoped<IRepo,Repo>();
builder.Services.AddLogging();


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

string connectionString = configuration.GetConnectionString("SqlConnection");


builder.Services.AddScoped<IDbConnection>( provider =>
{
    var connection = new SqlConnection(connectionString);
    return connection;
});


var app = builder.Build();

try{

    var supportedCultures = new[] { new CultureInfo("en-US") };
    app.UseRequestLocalization(new RequestLocalizationOptions
    {
        DefaultRequestCulture = new RequestCulture("en-US"),
        SupportedCultures = supportedCultures,
        SupportedUICultures = supportedCultures
    });
}
catch(Exception ex)
{
    Console.WriteLine("error at program.cs ",ex.Message);
}




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
