var builder = WebApplication.CreateBuilder(args);

// Aktiverar MVC-mönstret.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Aktiverar statiska filer (wwwroot).
app.UseStaticFiles(); 

// Aktiverar routing.
app.UseRouting();

// Routing.
app.MapControllerRoute( 
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();

