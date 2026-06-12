using Fiap.Api.Students.Data;
using Fiap.Api.Students.Data.Repository;
using Fiap.Api.Students.Mapping;
using Fiap.Api.Students.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


#region DATA BASE INITIALIZATION

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);

#endregion


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(config => config.AddProfile<MappingProfile>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepresentativeService, RepresentativeService>();
builder.Services.AddScoped<IRepresentativeRepository, RepresentativeRepository>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


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

app.Run();
