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
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "Departments";
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(TableName);

            builder
                .Property(x => x.Code)
                .HasMaxLength(3)
                .IsFixedLength();
        }
    }
}
