using Smurfs.Business.Abstract;
using Smurfs.Business.Concrete;
using Smurfs.Core.Abstract;
using Smurfs.DataAccess.Concrete;
using Smurfs.DataAccess.Concrete.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<SmurfsContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IBankService, BankManager>();
builder.Services.AddScoped<ILoginService, LoginManager>();
builder.Services.AddScoped<IProjectService, ProjectManager>();


builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(10);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    }
);

builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseAuthorization();

app.UseSession();

app.MapControllers();

app.Run();
