using Writely.PL.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.ConfigureSqlDatabase(builder.Configuration);
builder.Services.ConfigurationSettings(builder.Configuration);
builder.Services.ConfigureDependencies();
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddHttpContextAccessor();
builder.Services.AddJWTConfiguration(builder.Configuration);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=LoginUser}/{id?}");

app.Run();
