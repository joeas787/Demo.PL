using Demo.DAL.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Context.Configration
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name)
                .HasColumnType("VarChar")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnType("VarChar")
                .HasMaxLength(30)
                .IsRequired(false);

            builder.Property(e => e.PhoneNumber)
                .HasColumnType("Char")
                .HasMaxLength(11)
                .IsRequired(false);

            builder.Property(e => e.Salary)
                .HasColumnType("decimal(10,2)")
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(e => e.Gender).HasConversion(x => x.ToString(), s => Enum.Parse<Gender>(s));
            builder.Property(e => e.EmployeeType).HasConversion(x => x.ToString(), s => Enum.Parse<EmployeeType>(s));
        }
    }
}
