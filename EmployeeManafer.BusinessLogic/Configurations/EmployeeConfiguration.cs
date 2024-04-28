using EmployeeManager.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.BusinessLogic.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        private string tableName = "Employees";

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(tableName);
         

            builder
                .Property(x => x.FirstName)
                .HasMaxLength(255);

            builder
                .Property(x => x.LastName)
                .HasMaxLength (255);

            //relations

            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId);


            builder
                .HasOne(x => x.User)
                .WithOne(x => x.Employee)
                .HasForeignKey<Employee>(x => x.Id);

            //builder
            //    .HasMany(x => x.ProjectEmployees)
            //   .WithOne(x => x.Employee)
            //   .HasForeignKey(x => x.EmployeeId);



        }
    }
}
