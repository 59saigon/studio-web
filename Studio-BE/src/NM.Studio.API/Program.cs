using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NM.Studio.Domain.Configs.Mapping;
using NM.Studio.Domain.Contracts.Repositories.Events;
using NM.Studio.Domain.Contracts.Repositories.Locations;
using NM.Studio.Domain.Contracts.Repositories.Users;
using NM.Studio.Domain.Contracts.Repositories.Weddings;
using NM.Studio.Domain.Contracts.Services.Events;
using NM.Studio.Domain.Contracts.Services.Locations;
using NM.Studio.Domain.Contracts.Services.Users;
using NM.Studio.Domain.Contracts.Services.Weddings;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Services.Events;
using NM.Studio.Services.Locations;
using NM.Studio.Services.Users;
using NM.Studio.Services.Weddings;
using NM.Studio.Data.Context;
using NM.Studio.Data.Repositories.Events;
using NM.Studio.Data.Repositories.Locations;
using NM.Studio.Data.Repositories.Users;
using NM.Studio.Data.Repositories.Weddings;
using NM.Studio.Data.UnitOfWorks;
using System.Text;
using System.Text.Json.Serialization;
using NM.Studio.Domain.Contracts.Repositories.Photos;
using NM.Studio.Domain.Contracts.Repositories.Services;
using NM.Studio.Data.Repositories.Photos;
using NM.Studio.Data.Repositories.Services;
using NM.Studio.Domain.Contracts.Services.Services;
using NM.Studio.Services.Services;
using NM.Studio.Domain.Contracts.Services.Photos;
using NM.Studio.Services.Photos;
using System.Reflection;
using NM.Studio.Handler;

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
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
////Before 12.0.0
var handler = typeof(AppHandler).GetTypeInfo().Assembly;
builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), handler);

#endregion

#region Add-Scoped
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IWeddingRepository, WeddingRepository>();

builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IEventXPhotoRepository, EventXPhotoRepository>();
builder.Services.AddScoped<IEventXServiceRepository, EventXServiceRepository>();


builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();


#endregion

#region Add-Transient
builder.Services.AddTransient<IWeddingService, WeddingService>();

builder.Services.AddTransient<ILocationService, LocationService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<ICityService, CityService>();

builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IEventXPhotoService, EventXPhotoService>();
builder.Services.AddTransient<IEventXServiceService, EventXServiceService>();

builder.Services.AddTransient<IServiceService, ServiceService>();

builder.Services.AddTransient<IPhotoService, PhotoService>();

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
