using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MyTriApp.Data;
using MyTriApp.Extensions;
using MyTriApp.Services;
using MyTriApp.Services.Interfaces;
using MyTriApp.Strava_API;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var config = builder.Configuration;
var secretClient = new SecretClient(new Uri(config.GetSection("KeyVault")["VaultUri"]), new DefaultAzureCredential());
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSecretServices(config);
builder.Services.AddDbContext<MyTriAppDbContext>();
builder.Services.AddScoped<IMyTriAppDbContext, MyTriAppDbContext>();

if (builder.Environment.IsProduction())
{
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters  
        {
            ValidIssuer = secretClient.GetSecret("JWT-Issuer").Value.Value,
            ValidAudience = secretClient.GetSecret("JWT-Audience").Value.Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretClient.GetSecret("JWT-Key").Value.Value)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });
}

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = config["JWT-Issuer"],
            ValidAudience = config["JWT-Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT-Key"]!)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });
}

builder.Services.AddAuthorization();


//Add Services
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStravaAPI, StravaAPI>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IStravaAccessTokenService, StravaAccessTokenService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173").AllowAnyHeader();
                      });
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//needs to be after https
app.UseAuthentication();
app.UseAuthorization();
//and before controllers

app.MapControllers();

app.Run();
