using Beneyetna.BLL;
using Beneyetna.BLL.IServices;
using Beneyetna.BLL.Services;
using Beneyetna.Core;
using Beneyetna.DAL;
using Beneyetna.DAL.Interfaces;
using Beneyetna.DAL.Repositories;
using Beneyetna.DataContracts.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.AddScoped<IAccessTokenRepository, AccessTokenRepository>();
builder.Services.AddScoped<DALFacade, DALFacade>();
builder.Services.AddScoped<BLLFacade, BLLFacade>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyMethod()
           .AllowAnyHeader()
           .AllowAnyOrigin();
}));

builder.Services.AddDbContext<BeneyetnaContext>(o => o.UseMySQL(builder.Configuration?.GetConnectionString("Beneyetna4UDatabase")));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
