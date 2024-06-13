using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend_MindWave.ApplicationData;

public partial class MindWaveDbContext : DbContext
{
    public MindWaveDbContext()
    {
    }

    public MindWaveDbContext(DbContextOptions<MindWaveDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Characteristic> Characteristics { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<TestsAnswer> TestsAnswers { get; set; }

    public virtual DbSet<TestsQuestion> TestsQuestions { get; set; }

    public virtual DbSet<TestsView> TestsViews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersResult> UsersResults { get; set; }

    public virtual DbSet<UsersTest> UsersTests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=IgorPc\\SQLEXPRESS; Database=MindWaveDb; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Characteristic>(entity =>
        {
            entity.Property(e => e.CharacteristicId).HasColumnName("characteristic_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.Property(e => e.TestId).HasColumnName("test_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CoverImage).HasColumnName("cover_image");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.Category).WithMany(p => p.Tests)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tests_Categories");
        });

        modelBuilder.Entity<TestsAnswer>(entity =>
        {
            entity.HasKey(e => e.TestAnswerId);

            entity.Property(e => e.TestAnswerId).HasColumnName("test_answer_id");
            entity.Property(e => e.Answer)
                .HasMaxLength(100)
                .HasColumnName("answer");
            entity.Property(e => e.Mark)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("mark");
            entity.Property(e => e.TestQuestionId).HasColumnName("test_question_id");

            entity.HasOne(d => d.TestQuestion).WithMany(p => p.TestsAnswers)
                .HasForeignKey(d => d.TestQuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestsAnswers_TestsQuestions");
        });

        modelBuilder.Entity<TestsQuestion>(entity =>
        {
            entity.HasKey(e => e.TestQuestionId);

            entity.Property(e => e.TestQuestionId).HasColumnName("test_question_id");
            entity.Property(e => e.CharacteristicId).HasColumnName("characteristic_id");
            entity.Property(e => e.Question)
                .HasMaxLength(500)
                .HasColumnName("question");
            entity.Property(e => e.TestId).HasColumnName("test_id");

            entity.HasOne(d => d.Characteristic).WithMany(p => p.TestsQuestions)
                .HasForeignKey(d => d.CharacteristicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestsQuestions_Characteristics");

            entity.HasOne(d => d.Test).WithMany(p => p.TestsQuestions)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestsQuestions_Tests");
        });

        modelBuilder.Entity<TestsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TestsView");

            entity.Property(e => e.Answer)
                .HasMaxLength(100)
                .HasColumnName("answer");
            entity.Property(e => e.CharacteristicId).HasColumnName("characteristic_id");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Mark)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("mark");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Question)
                .HasMaxLength(500)
                .HasColumnName("question");
            entity.Property(e => e.TestAnswerId).HasColumnName("test_answer_id");
            entity.Property(e => e.TestId).HasColumnName("test_id");
            entity.Property(e => e.TestQuestionId).HasColumnName("test_question_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<UsersResult>(entity =>
        {
            entity.HasKey(e => e.UserResultId);

            entity.Property(e => e.UserResultId).HasColumnName("user_result_id");
            entity.Property(e => e.CharacteristicId).HasColumnName("characteristic_id");
            entity.Property(e => e.Rating)
                .HasColumnType("int")
                .HasColumnName("rating");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Characteristic).WithMany(p => p.UsersResults)
                .HasForeignKey(d => d.CharacteristicId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsersResults_Characteristics");

            entity.HasOne(d => d.User).WithMany(p => p.UsersResults)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsersResults_Users");
        });

        modelBuilder.Entity<UsersTest>(entity =>
        {
            entity.HasKey(e => e.UserTestId);

            entity.Property(e => e.UserTestId).HasColumnName("user_test_id");
            entity.Property(e => e.TestId).HasColumnName("test_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Test).WithMany(p => p.UsersTests)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsersTests_Tests");

            entity.HasOne(d => d.User).WithMany(p => p.UsersTests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsersTests_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
