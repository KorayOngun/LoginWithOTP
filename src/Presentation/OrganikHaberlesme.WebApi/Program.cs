using OrganikHaberlesme.Persistence;
using OrganikHaberlesme.Application;
using OrganikHaberlesme.Infrastructure;
using OrganikHaberlesme.LoginClaim;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var _dbPath = builder.Configuration.GetConnectionString("SqlCon");


builder.Services.AddPersistence(_dbPath);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddLoginClaim(builder.Configuration);


if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(opt =>
    {
        opt.AddPolicy("AllowOrigin",policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
    });
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("AllowOrigin");
}

app.UseHttpsRedirection();

app.UseHangfireServer();

app.Services.DbSeed();

app.UseAuthorization();


app.MapControllers();

app.Run();
