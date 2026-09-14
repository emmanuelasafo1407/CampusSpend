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
    public DbSet<StudyScheduleSlot> StudyScheduleSlots => Set<StudyScheduleSlot>();
    public DbSet<UserFreeWindow> UserFreeWindows => Set<UserFreeWindow>();
    public DbSet<ProjectDailyLog> ProjectDailyLogs => Set<ProjectDailyLog>();
    public DbSet<SystemPreference> SystemPreferences => Set<SystemPreference>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BudgetSetting>().HasData(new BudgetSetting
        {
            Id = 1,
            TargetAmount = 0.00m,
            PeriodType = "Monthly",
            CustomDailyTarget = 0.00m,
            IsExamLockoutActive = false,
            ExamLockoutStartDate = null,
            ExamLockoutEndDate = null,
            UpdatedAt = new DateTime(2026, 1, 1)
        });

        modelBuilder.Entity<SystemPreference>().HasData(new SystemPreference
        {
            Id = 1,
            SemesterStartDate = new DateTime(2026, 8, 15),
            RevisionWeekStartDate = new DateTime(2026, 11, 20),
            SemesterEndDate = new DateTime(2026, 12, 18),
            DefaultLectureStartTime = new TimeSpan(8, 0, 0),
            DefaultLectureEndTime = new TimeSpan(17, 0, 0),
            PreferredCurrency = "GHS",
            DefaultPaymentMethod = "Mobile Money",
            LockLifestyle = true,
            LockUtilities = false,
            LockFoodTakeout = false,
            RunwayAlertThresholdDays = 14,
            DefaultFocusBlockMinutes = 25,
            DefaultAmbienceTrack = "deep-brown",
            Enable10MinChime = true,
            IsDarkMode = false,
            AutoPlaySplashScreen = true,
            UpdatedAt = new DateTime(2026, 1, 1)
        });
    }
}