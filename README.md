# NhuMyStudio_WebAPI
DBFirst:
+ (Create)
Scaffold-DbContext "Data Source=.;Initial Catalog=Studio;Persist Security Info=True;User ID=sa;Password=12345;Encrypt=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
+ (Update)
Scaffold-DbContext "Data Source=.;Initial Catalog=Studio;Persist Security Info=True;User ID=sa;Password=12345;Encrypt=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force

"ConnectionStrings": {
    "DefaultConnection": "Data Source=.;Initial Catalog=Studio;Persist Security Info=True;User ID=sa;Password=12345;Encrypt=True;Trust Server Certificate=True"
  }

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }
