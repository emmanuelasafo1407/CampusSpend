using Microsoft.EntityFrameworkCore;
using CampusSpend.Data;
using CampusSpend.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=campusspend_v2.db"));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=campusspend_v3.db"));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=campusspend_v4.db"));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=campusspend_v5.db"));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=campusspend_v6.db"));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=campusspend_v7.db"));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=campusspend_v8.db"));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=campusspend_v9.db"));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=campusspend_v10.db"));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=campusspend_v11.db"));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=campusspend_v12.db"));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=campusspend_v13.db"));

builder.Services.AddDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=campusspend_v14.db"));

var app = builder.Build();

// Auto-create database schema and seed default budget if empty
using (var scope = app.Services.CreateScope())
{
    var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
    using var db = factory.CreateDbContext();
    db.Database.EnsureCreated();

    if (!db.BudgetSettings.Any())
    {
        db.BudgetSettings.Add(new BudgetSetting { PeriodType = "Monthly", TargetAmount = 600.00m });
        db.SavingsGoals.Add(new SavingsGoal { Title = "Semester Project & Hardware Kits", TargetAmount = 500.00m, CurrentSaved = 150.00m });
        db.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<CampusSpend.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();