global using Ecommerce.Services;
using Bussiness.Abstract;
using Bussiness.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Ecommerce.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using Swashbuckle.AspNetCore.Filters;
using System.Security.Claims;
using StackExchange.Redis.Configuration;
using IUserService = Bussiness.Abstract.IUserService;
using Microsoft.Extensions.Caching.StackExchangeRedis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IUserService, UserManagement>();
builder.Services.AddSingleton<IUserDal, EFUserDal>();
//builder.Services.AddSingleton<IClassService, ClassManage>();
//builder.Services.AddSingleton<IClassDal, EFClassDal>();
//builder.Services.AddSingleton<ITeacherService, TeacherManage>();
//builder.Services.AddSingleton<ITeacherDal, EFTeacherDal>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var multiplexer = ConnectionMultiplexer.Connect("localhost");
builder.Services.AddSingleton<RedisCache>();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oath2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Standart",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,

    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Spider2000spider2000SPIDER2000")),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    }
    );
builder.Services.Configure<IdentityOptions>(options =>
    options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);
builder.Services.AddScoped<uIUserService, uUserService>();


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
