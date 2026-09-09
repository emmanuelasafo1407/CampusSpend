using Microsoft.EntityFrameworkCore;
using CampusSpend.Models;

namespace CampusSpend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<BudgetSetting> BudgetSettings => Set<BudgetSetting>();
    public DbSet<SavingsGoal> SavingsGoals => Set<SavingsGoal>();
    public DbSet<StudyTask> StudyTasks => Set<StudyTask>();
    public DbSet<SemesterCourse> SemesterCourses => Set<SemesterCourse>();
}