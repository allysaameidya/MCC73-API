using API2.Context;
using API2.Repository.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<AccountRepositories>();
builder.Services.AddScoped<AccountRoleRepositories>();
builder.Services.AddScoped<EducationRepositories>();
builder.Services.AddScoped<EmployeeRepositories>();
builder.Services.AddScoped<ProfilingRepositories>();
builder.Services.AddScoped<RoleRepositories>();
builder.Services.AddScoped<UniversityRepositories>();

// Configure SQL Server Databases
builder.Services.AddDbContext<MyContext>(options => options
        .UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

// Configure JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            // Usually, this is your application base URL
            //ValidAudience = builder.Configuration["JWT:Audience"],
            ValidateAudience = false,
            //If the JWT is created by using a web service, then this would be the consumer URL           
            //ValidIssuer = builder.Configuration["JWT:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x=>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MCC73 API",
        Description = "ASP.NET Core API 6.0"
    });

    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{ }
        }
    });
});

// Menambahkan CORS untuk membatasi akses client dalam web/API kita
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
