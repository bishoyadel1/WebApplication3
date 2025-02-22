using AutoMapper;
using Domin.Context;
using Infrastucture.Interface;
using Infrastucture.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApplication3.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Fix here





builder.Services.AddIdentity<IdentityUser, IdentityRole>(ob =>
{
    ob.Password.RequireNonAlphanumeric = false;
    ob.Password.RequireUppercase = false;
    ob.Password.RequiredLength = 5;
})
       .AddEntityFrameworkStores<StoreDbContext>()
       .AddDefaultTokenProviders();




builder.Services.AddScoped<IProductRepository,  ProductRepository>();
builder.Services.AddScoped<ITokenServices, TokenServices>();
builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IBasketRepostiroy, BasketRepostiroy>();
builder.Services.AddScoped (typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddAuthentication(Options =>
{
    Options.DefaultAuthenticateScheme = "Default";
    Options.DefaultChallengeScheme = "Default";
})

.AddJwtBearer("Default", options =>
{
    //var KeyString = builder.Configuration.GetValue<string>("JWT:Key");   
    var KeyString = builder.Configuration.GetValue<string>("SecretKey");
    var KeyInBytes = Encoding.ASCII.GetBytes(KeyString);
    var Key = new SymmetricSecurityKey(KeyInBytes);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = Key,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        var secretKey = builder.Configuration.GetValue<string>("SecretKey");
//        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = key,
//            ValidateIssuer = false,
//            ValidateAudience = false,
//            ValidateLifetime = true
//        };

//        //options.Events = new JwtBearerEvents
//        //{
//        //    OnAuthenticationFailed = context =>
//        //    {
//        //        Console.WriteLine($" Authentication Failed: {context.Exception.Message}");
//        //        return Task.CompletedTask;
//        //    },
//        //    OnTokenValidated = context =>
//        //    {
//        //        Console.WriteLine( "Token Successfully Validated");
//        //        return Task.CompletedTask;
//        //    }
//        //};
//    });





builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

  
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token in the format: Bearer YOUR_TOKEN_HERE"
    });

 
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new string[] {}  
        }
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Enable Swagger authentication
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        options.DisplayRequestDuration(); // Shows API request duration
    });
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();



//app.Use(async (context, next) =>
//{
//    try
//    {
//        await next.Invoke();
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Unhandled error: {ex.Message}");
//        throw;
//    }
//});
