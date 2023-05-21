using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SqlDatabaseFirstApproach.Models;

public partial class VolleyballContext : DbContext
{
    public VolleyballContext()
    {
    }

    public VolleyballContext(DbContextOptions<VolleyballContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> Persons { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Volleyball;Trusted_Connection=True;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persons__3214EC07660FA447");

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CoachId).HasColumnName("coach_id");
            entity.Property(e => e.Country)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Weight).HasColumnName("weight");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
