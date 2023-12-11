using GetirClone.Application;
using GetirClone.Application.Responses;
using GetirClone.Application.Tools;
using GetirClone.Application.Utilities;
using GetirClone.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddApplicationService();
builder.Services.AddMessagingServices();
builder.Services.AddPersistanceServices(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(config =>
    {
        config.WithOrigins("http://localhost:3000", "https://localhost:3000",
                           "http://localhost:3001", "https://localhost:3001").
                           AllowAnyHeader().AllowAnyMethod();
    });
}
);

var app = builder.Build();
app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync(new ResultModel<object>
            {
                IsSuccessful = false,
                Errors = new List<ErrorModel>
                            {
                                new ErrorModel
                                {
                                    ErrorCode = "1001",
                                    ErrorMessage = contextFeature.Error.Message
                                }
                            },
                Result = null
            }.ToJson());

        }
    });
});

app.UseStaticFiles();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();


    app.UseSwaggerUI(x =>
    {
        x.DisplayRequestDuration();
    });
}

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();