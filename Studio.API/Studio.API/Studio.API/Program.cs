using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Studio.API.Business.Domain.Configs.Mapping;
using Studio.API.Business.Domain.Contracts.Repositories.Weddings;
using Studio.API.Business.Domain.Contracts.Services.Weddings;
using Studio.API.Business.Domain.Contracts.UnitOfWorks;
using Studio.API.Business.Services.Weddings;
using Studio.API.Data.Context;
using Studio.API.Data.Repositories.Weddings;
using Studio.API.Data.UnitOfWorks;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
#region Add-DbContext
builder.Services.AddDbContext<StudioContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

builder.Services.AddControllers();

#region Config-Json
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
#endregion

#region Add-AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
#endregion

#region Add-MediaR

//After 12.0.0
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
////Before 12.0.0
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

#endregion

#region Add-Scoped
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IWeddingRepository, WeddingRepository>();


#endregion

#region Add-Transient

builder.Services.AddTransient<IWeddingService, WeddingService>();

#endregion

#region Config-Authentication_Authorization
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetValue<string>("Appsettings:Token"))),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();
#endregion

#region Add-Cors

builder.Services.AddCors(p => p.AddPolicy("admin", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors("admin");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();
