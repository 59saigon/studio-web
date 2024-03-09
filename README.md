# NhuMyStudio_WebAPI

Scaffold-DbContext "Data Source=.;Initial Catalog=Studio;Persist Security Info=True;User ID=sa;Password=12345;Encrypt=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

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
-- Tạo bảng Role
CREATE TABLE [dbo].[Role](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [roleId] [uniqueidentifier] NOT NULL DEFAULT NEWID() unique,
    [title] [nvarchar](max) NOT NULL,
    [roleName] [nvarchar](max) NOT NULL,
    [createdBy] [nvarchar](36) NULL,
    [createdDate] [datetime2](7) NOT NULL,
    PRIMARY KEY CLUSTERED 
    (
        [id] ASC
    )
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

-- Tạo bảng User
CREATE TABLE [dbo].[User](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [userId] [uniqueidentifier] NOT NULL DEFAULT NEWID() unique,
    [fullName] [nvarchar](max) NOT NULL,
    [email] [nvarchar](max) NOT NULL,
    [dob] [date] NOT NULL,
    [address] [nvarchar](max) NOT NULL,
    [gender] [nvarchar](max) NOT NULL,
    [phone] [nvarchar](max) NOT NULL,
    [username] [nvarchar](max) NOT NULL,
    [password] [nvarchar](max) NOT NULL,
    [roleId] [int] NOT NULL,
    [createdBy] [nvarchar](36) NULL,
    [createdDate] [datetime2](7) NOT NULL,
    [avatar] [nvarchar](max) NULL,
    [Status] [nvarchar](max) NULL,
    PRIMARY KEY CLUSTERED 
    (
        [id] ASC
    ),
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([roleId]) REFERENCES [Role]([roleId])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[Moment](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [momentId] [uniqueidentifier] NOT NULL DEFAULT NEWID() unique,
    [picture] [nvarchar](max) NULL,
    [date] [datetime2](7) NOT NULL,
    [title] [nvarchar](max) NOT NULL,
    [content] [nvarchar](max) NOT NULL,
    [userId] [uniqueidentifier] NOT NULL,  -- Khóa ngoại tham chiếu đến bảng User
    [createdBy] [nvarchar](36) NULL,
    [createdDate] [datetime2](7) NOT NULL,
    PRIMARY KEY CLUSTERED 
    (
        [id] ASC
    ),
    CONSTRAINT [FK_Moment_User] FOREIGN KEY ([userId]) REFERENCES [User]([userId])
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
