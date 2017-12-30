using System.Data.Entity.ModelConfiguration;
using EmployeeManagement.Model;

namespace EmployeeManagement.Data
{
    public class EmployeeConfig : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfig(string table = "Employees", string schema = "dbo")
        {
            ToTable(table, schema);
            HasKey(e => e.Id);
            Property(e => e.Name).HasMaxLength(100).IsRequired();
            Property(e => e.PhoneNumber).HasMaxLength(25).IsRequired();
            Property(e => e.EmailAddress).HasMaxLength(50).IsRequired();
            Property(e => e.BirthDate).HasColumnType("date");
            Ignore(e => e.Age);
        }
    }

    public class StateConfig : EntityTypeConfiguration<State>
    {
        public StateConfig(string table = "States", string schema = "dbo")
        {
            ToTable(table, schema);
            HasKey(s => s.Id);
            Property(s => s.Abbreviation).HasMaxLength(2).IsRequired();
            Property(s => s.Name).HasMaxLength(50).IsRequired();

            HasMany(s => s.Employees).WithRequired(e => e.State).HasForeignKey(e => e.StateId).WillCascadeOnDelete(false);
        }
    }

    public class GenderConfig : EntityTypeConfiguration<Gender>
    {
        public GenderConfig(string table = "Genders", string schema = "dbo")
        {
            ToTable(table, schema);
            HasKey(g => g.Id);
            Property(g => g.Name).HasMaxLength(6).IsRequired();

            HasMany(g => g.Employees).WithRequired(e => e.Gender).HasForeignKey(e => e.GenderId).WillCascadeOnDelete(false);
        }
    }

    public class DegreeConfig : EntityTypeConfiguration<Degree>
    {
        public DegreeConfig(string table = "Degrees", string schema = "dbo")
        {
            ToTable(table, schema);
            HasKey(d => d.Id);
            Property(d => d.Level).HasMaxLength(50).IsRequired();
            Property(d => d.Major).HasMaxLength(100).IsRequired();

            HasMany(d => d.Employees).WithRequired(e => e.Degree).HasForeignKey(e => e.DegreeId).WillCascadeOnDelete(false);
        }
    }
}
