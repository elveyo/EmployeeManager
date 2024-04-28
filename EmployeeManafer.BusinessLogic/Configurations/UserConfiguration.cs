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
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder
                .Property(x => x.Email)
                .HasMaxLength(255);

            builder
                .Property(x => x.Username)
                .HasMaxLength(15);

            //relations

            builder
                .HasOne(x => x.Employee)
                .WithOne(x => x.User)
                .HasForeignKey<Employee>(x => x.Id);
        }


    }
}
