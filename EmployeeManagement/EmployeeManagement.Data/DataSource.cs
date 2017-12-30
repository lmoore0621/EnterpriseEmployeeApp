using System.Data.Entity;
using EmployeeManagement.Model;

namespace EmployeeManagement.Data
{
    public class DataSource : DbContext
    {
        public DataSource()
            : base("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=EmployeeDb;Integrated Security=true")
        {

        }

        public DataSource(string connString)
            : base(connString)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Degree> Degrees { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfig());
            modelBuilder.Configurations.Add(new DegreeConfig());
            modelBuilder.Configurations.Add(new GenderConfig());
            modelBuilder.Configurations.Add(new StateConfig());
        }
    }
}
