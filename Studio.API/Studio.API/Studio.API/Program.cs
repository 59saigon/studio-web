using Microsoft.EntityFrameworkCore;
using Studio.API.Context;
using Studio.API.Repositories.Classes;
using Studio.API.Repositories.Interfaces;
using Studio.API.Services.Classes;
using Studio.API.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.
builder.Services.AddDbContext<StudioContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//Add scope
builder.Services.AddScoped<I_MomentRepository, MomentRepository>();
builder.Services.AddScoped<I_RoleRepository, RoleRepository>();
builder.Services.AddScoped<I_UserRepository, UserRepository>();

//Add service
builder.Services.AddTransient<I_MomentService, MomentService>();

//End - add scope
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpLogging();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();

app.Run();
