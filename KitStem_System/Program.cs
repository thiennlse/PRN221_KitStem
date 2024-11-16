using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Reposiory;
using Reposiory.Interface;
using Service;
using Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddDbContext<KitStemDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("local")));
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILabRepository, LabRepository>();
builder.Services.AddScoped<ILabService, LabService>();
builder.Services.AddScoped<IKitRepository, KitRepository>();
builder.Services.AddScoped<IKitService, KitService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IStepRepository, StepRepository>();
builder.Services.AddScoped<IStepService, StepService>();
builder.Services.AddScoped<IUserLabService, UserLabService>();
builder.Services.AddScoped<IUserLabRepository, UserLabRepository>();
builder.Services.AddScoped<IHelpHistoryService, HelpHistoryService>();
builder.Services.AddScoped<IHelpHistoryRepository, HelpHistoryRepository>();
builder.Services.AddScoped<FirebaseService>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);  
    options.Cookie.HttpOnly = true;                
    options.Cookie.IsEssential = true;             
});

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
