using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParkMap.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ParkMapContextConnection") ?? throw new InvalidOperationException("Connection string 'ParkMapContextConnection' not found.");

builder.Services.AddDbContext<ParkMapContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ParkMapUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ParkMapContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Authorization
void AddAuthorizationPolicies(IServiceCollection services)
{
    /*
    services.AddAuthorization(options =>
     {
         options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Administrator"));
         options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
         options.AddPolicy("RequireAdministratorOrUserRole", policy => policy.RequireRole("Administrator", "User"));
     });
     */
    services.AddAuthorization(options =>
    {
        options.AddPolicy("RequireAdministratorRole", policy => policy.RequireRole("Administrator"));
        options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
    });
}

AddAuthorizationPolicies(builder.Services);
#endregion

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
