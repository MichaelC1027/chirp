using chirp_api.Data;
using chirp_api.Services;
using chirp_api.Services.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;
using System.Text;
using Scalar.AspNetCore;

//The Builder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//The Database Service
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//Adding IServices and Services to scope
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IFollowService, FollowService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IUserService, UserService>();

//JWT Authentication section
//getting the key, issuer, and audience
var key = builder.Configuration.GetSection("JWT:Key").Value;
var issuer = builder.Configuration.GetSection("JWT:Issuer").Value;
var audience = builder.Configuration.GetSection("JWT:Audience").Value;

//builder call for JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!))
    };
});

//Adding controller
builder.Services.AddControllers();
//leaving this openAPI call incase (delete in prod if its useless)
builder.Services.AddOpenApi();

//Build the app
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();//HTTPS call

app.UseStaticFiles(); //for the default PFP

app.UseAuthentication(); //JWT Authentication

app.UseAuthorization(); //JWT Authorization

app.MapControllers();//API Endpoints

app.Run();//this just runs it 