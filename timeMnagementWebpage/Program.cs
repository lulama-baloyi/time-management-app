using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using timeMnagementWebpage.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add database context
var connectionString = builder.Configuration.GetConnectionString("DBContextSampleConnection")
    ?? throw new InvalidOperationException("Connection string 'DBContextSampleConnection' not found.");

builder.Services.AddDbContext<DBContextSample>(options =>
    options.UseSqlServer(connectionString));

// Configure Identity for user authentication
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireDigit = true; // Ensure password has at least one digit
    options.Password.RequiredLength = 8; // Minimum password length
    options.Password.RequireNonAlphanumeric = false; // Non-alphanumeric characters not required
    options.Password.RequireUppercase = false; // Optional: Adjust based on security needs
    options.SignIn.RequireConfirmedAccount = false; // Email confirmation is not required
})
.AddEntityFrameworkStores<DBContextSample>();

// Add MVC services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Use detailed error pages during development
}
else
{
    app.UseExceptionHandler("/Home/Error"); // Use custom error handling in production
    app.UseHsts(); // Enforce strict HTTPS
}

// Middleware pipeline
app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseStaticFiles(); // Serve static files (CSS, JS, images, etc.)
app.UseRouting(); // Enable routing
app.UseAuthentication(); // Enable authentication middleware
app.UseAuthorization();  // Enable authorization middleware

// Configure routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages(); // Map Razor Pages (for Identity pages like login, register, etc.)

// Run the application
app.Run();
