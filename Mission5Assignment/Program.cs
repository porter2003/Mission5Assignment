// Creates a builder for the web application using command-line arguments
var builder = WebApplication.CreateBuilder(args);

// Adds services to the container that will be used by the app, including support for controllers and views
builder.Services.AddControllersWithViews();

// Builds the web application using the services defined above
var app = builder.Build();

// Configures the HTTP request pipeline. This code defines how requests are handled by the app.
// The following checks if the app is not in development mode (production or staging).
if (!app.Environment.IsDevelopment())
{
    // If not in development, use a custom error handler page for unhandled exceptions
    app.UseExceptionHandler("/Home/Error");

    // Enables HTTP Strict Transport Security (HSTS) in production for better security.
    // This tells browsers to only access the site over HTTPS for the next 30 days.
    // You may want to adjust this duration for your production scenario.
    app.UseHsts();
}

// Redirects HTTP requests to HTTPS to ensure secure connections
app.UseHttpsRedirection();

// Serves static files (e.g., images, CSS, JavaScript) from the wwwroot folder
app.UseStaticFiles();

// Configures routing so the app can map incoming requests to the correct controller and action
app.UseRouting();

// Enables authorization middleware to secure parts of the app that require user authentication
app.UseAuthorization();

// Configures the default route for the app. It maps URLs to controllers and actions.
app.MapControllerRoute(
    name: "default",                     // Defines a name for the route (for routing purposes)
    pattern: "{controller=Home}/{action=Index}/{id?}"); // The URL pattern for the route

// Runs the web application
app.Run();
