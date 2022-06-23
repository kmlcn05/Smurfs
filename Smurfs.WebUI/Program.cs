using Smurfs.WebUI.Services;
using Smurfs.WebUI.Services.Interfaces;
using Smurfs.WebUI.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IProjectService, ProjectService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    endpoints.MapRazorPages();
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
