using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyGalaxy_Auction_Business.Abraction;
using MyGalaxy_Auction_Business.Concrete;
using MyGalaxy_Auction_Core.Models;
using MyGalaxy_Auction_Data_Access.Context;
using MyGalaxy_Auction_Data_Access.Models;
using System.Reflection;
using AutoMapper;
using MyGalaxy_Auction.Extensions;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddDbContextLayer(builder.Configuration);
builder.Services.AddSwaggerCollection(builder.Configuration);
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();
var options = new JsonSerializerOptions
{
    ReferenceHandler = ReferenceHandler.Preserve
};
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
