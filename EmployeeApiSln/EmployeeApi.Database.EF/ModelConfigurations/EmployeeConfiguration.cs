using EmployeeApi.Database.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeApi.Database.EF.ModelConfigurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(employee => employee.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(employee => employee.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(employee => employee.Position)
                .HasColumnName("position")
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(employee => employee.Salary)
                .HasColumnName("salary")
                .HasColumnType("decimal(10, 2)")
                .IsRequired();

            builder.Property(employee => employee.JoinDate)
                .HasColumnName("join_date")
                .IsRequired();
        }
    }
}
