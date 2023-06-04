using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RunoLandingPage.Models;
using System.Configuration;




var builder = WebApplication.CreateBuilder(args);
var connectionString01 = builder.Configuration.GetConnectionString("RunoDbAzure");

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString01));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();


//builder.Services.BuildServiceProvider().GetService<AppDbContext>().Database.Migrate();


builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddScoped<IGenericRepository<Request>, GenericRepository<Request>>();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();


//if (app.Environment.IsDevelopment())
//{
//    app.UseMigrationsEndPoint();
//}
//else
//{
//    app.UseStatusCodePagesWithReExecute("/Error/{0}");
//    app.UseHsts();
//}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    // app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Chingiz",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
