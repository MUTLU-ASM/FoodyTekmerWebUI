using FoodyTekmerBusinessLayer.Abstract;
using FoodyTekmerBusinessLayer.Concrete;
using FoodyTekmerBusinessLayer.Container;
using FoodyTekmerDataAccessLayer.Abstract;
using FoodyTekmerDataAccessLayer.Context;
using FoodyTekmerDataAccessLayer.EntityFramework;
using FoodyTekmerEntityLayer.Concrete;
using FoodyTekmerWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ContainerDependencies();

builder.Services.AddDbContext<FoodyContext>();

// Add services to the container.
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<FoodyContext>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<FoodyContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder()
	.RequireAuthenticatedUser()
	.Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseStatusCodePagesWithRedirects("/StatusCodeError/{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
