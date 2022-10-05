using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using UniversitySystem.Application.Middlewares;
using UniversitySystem.Application.ServiceRegistration;
using UniversitySystem.Persistence.ServiceRegistration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(opt =>
//{
//opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Airbnb API", Version = "v1" });
//opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//{
//    Scheme = "Bearer",
//    BearerFormat = "JWT",
//    In = ParameterLocation.Header,
//    Name = "Authorization",
//    Description = "Bearer Authentication with JWT Token",
//    Type = SecuritySchemeType.Http
//});

//opt.AddSecurityRequirement(new OpenApiSecurityRequirement
//                {
//                     {
//                        new OpenApiSecurityScheme
//                         {
//                            Reference= new OpenApiReference
//                            {
//                                Id="Bearer",
//                                Type=ReferenceType.SecurityScheme
//                            }
//                         },
//                        new List<string>()
//                     }
//});

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Airbnb API", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                     {
                        new OpenApiSecurityScheme
                         {
                            Reference= new OpenApiReference
                            {
                                Id="Bearer",
                                Type=ReferenceType.SecurityScheme
                            }
                         },
                        new List<string>()
                     }
                });
}
);


builder.Services.AddPersistenceRegistration(builder.Configuration);
builder.Services.AddApplicationServiceRegistration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddlewear>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();