using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TripCalculator;

namespace WebAPITripCalculator.DAL
{
    public class TripCalculatorContext:DbContext
    {
        public TripCalculatorContext():base("TripCalculatorContext")
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class TripCalculatorInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TripCalculatorContext>
    {
        protected override void Seed(TripCalculatorContext context)
        {
            var students = new List<Student>
            {
            new Student{ID = "1", Name="Lom P", TTpay = 0.00, Balance = 0.00 },
            new Student{ID = "2", Name="John Dole", TTpay = 0.00, Balance = 0.00},
            new Student{ID = "3", Name="Mark White", TTpay = 0.00, Balance = 0.00}

            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            context.Expenses.Create();
            context.SaveChanges();
        }
    }
}
