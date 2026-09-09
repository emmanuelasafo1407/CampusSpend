using System;
using System.ComponentModel.DataAnnotations;

namespace CampusSpend.Models;

public class Expense
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(80)]
    public string Description { get; set; } = "";

    [Required]
    [Range(0.10, 50000.00, ErrorMessage = "Enter an amount greater than 0.")]
    public decimal Amount { get; set; }

    [Required]
    public string Category { get; set; } = "Food"; 
    // Food, Academics, Transport, Data/Airtime, Utilities, Lifestyle

    [Required]
    public string PaymentMethod { get; set; } = "Mobile Money";

    [Required]
    public DateTime DateIncurred { get; set; } = DateTime.Today;
}

public class BudgetSetting
{
    public int Id { get; set; }

    [Required]
    public string PeriodType { get; set; } = "Monthly"; // Daily, Weekly, Monthly, Yearly

    [Range(1.00, 1000000.00)]
    public decimal TargetAmount { get; set; } = 800.00m;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

public class SavingsGoal
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Goal title is required.")]
    public string Title { get; set; } = "";

    [Range(1.00, 500000.00)]
    public decimal TargetAmount { get; set; } = 1500.00m;

    [Range(0.00, 500000.00)]
    public decimal CurrentSaved { get; set; } = 0.00m;

    public DateTime TargetDate { get; set; } = DateTime.Today.AddMonths(3);

    public bool IsCompleted => CurrentSaved >= TargetAmount;
    public bool IsArchived { get; set; } = false; // Moves to Achievements
    public DateTime? CompletedAt { get; set; }
}

public class StudyTask
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Course code is required (e.g. CPEN302).")]
    [StringLength(10)]
    public string CourseCode { get; set; } = "";

    [Required(ErrorMessage = "Topic title is required.")]
    [StringLength(80)]
    public string TopicTitle { get; set; } = "";

    [Range(1, 24, ErrorMessage = "Hours must be between 1 and 24.")]
    public int EstimatedHours { get; set; } = 2;

    [Required]
    public string Priority { get; set; } = "High"; // High, Medium, Low

    public DateTime ExamDate { get; set; } = DateTime.Today.AddDays(7);

    public bool IsCompleted { get; set; } = false;
    public DateTime? CompletedAt { get; set; }
}

public class SemesterCourse
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Course Code is required (e.g. CPEN302).")]
    [StringLength(12)]
    public string Code { get; set; } = "";

    [Required(ErrorMessage = "Course Title is required.")]
    [StringLength(80)]
    public string Title { get; set; } = "";

    [Range(1, 6, ErrorMessage = "Credit hours must be between 1 and 6.")]
    public int CreditHours { get; set; } = 3;

    [Range(1, 200, ErrorMessage = "Total slides must be at least 1.")]
    public int TotalSlides { get; set; } = 10;

    [Range(0, 200, ErrorMessage = "Covered slides cannot exceed bounds.")]
    public int CoveredSlides { get; set; } = 0;

    public double SlideProgress => TotalSlides > 0 ? ((double)CoveredSlides / TotalSlides) * 100 : 0;
    public bool IsFullyCovered => CoveredSlides >= TotalSlides;
}