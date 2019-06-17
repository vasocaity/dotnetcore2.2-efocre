using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace scaffold.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Grade> Grade { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=localhost;User=root;Password=password;Database=mydb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("grade", "mydb");

                entity.Property(e => e.GradeId)
                    .HasColumnName("grade_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GradeName)
                    .HasColumnName("grade_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GradeSection)
                    .HasColumnName("grade_section")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student", "mydb");

                entity.HasIndex(e => e.CurrentGradeId)
                    .HasName("current_grade_id");

                entity.Property(e => e.StudentId)
                    .HasColumnName("student_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CurrentGradeId)
                    .HasColumnName("current_grade_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");

                entity.Property(e => e.StudentName)
                    .HasColumnName("student_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CurrentGrade)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.CurrentGradeId)
                    .HasConstraintName("student_ibfk_1");
            });
        }
    }
}
