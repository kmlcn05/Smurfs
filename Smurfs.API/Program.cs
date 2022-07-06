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
builder.Services.AddScoped<ICallService, CallManager>();
    
builder.Services.AddScoped<IUserGroupService, UserGroupManager>();
builder.Services.AddScoped<ITeamService, TeamManager>();
builder.Services.AddScoped<IStatusService, StatusManager>();
builder.Services.AddScoped<IProcessService, ProcessManager>();
builder.Services.AddScoped<IDZDStatusService,DZDStatusManager>();
builder.Services.AddScoped<IPremiumService, PremiumManager>();
builder.Services.AddScoped<ILogService, LogManager>();
builder.Services.AddScoped<IDepartmentService, DepartmentManager>();
builder.Services.AddScoped<ICallStatusService, CallStatusManager>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<ICallParametersService, CallParametersManager>();
builder.Services.AddScoped<IProjectParametersService, ProjectParametersManager>();
builder.Services.AddScoped<IEmailService, EmailManager>();
builder.Services.AddScoped<IGeneralPremiumService, GeneralPremiumManager>();


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
