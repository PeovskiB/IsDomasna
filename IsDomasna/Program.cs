using IsDomasna.Data;
using IsDomasna.Repository.YourAppName.Data.Repositories;
using IsDomasna.Repository;
using IsDomasna.Service;
using Microsoft.EntityFrameworkCore;
using IsDomasna.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseInMemoryDatabase("TicketDatabase");
});

//builder.Services.AddIdentity<CinemaUser, IdentityRole>(options =>
//{

//});

builder.Services.AddIdentity<CinemaUser, IdentityRole>().AddEntityFrameworkStores < ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights", policy =>
          policy.RequireRole("Administrator"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Ticket}/{action=Index}/{id?}");

app.Run();
