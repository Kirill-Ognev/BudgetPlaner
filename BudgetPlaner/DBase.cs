using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BudgetPlaner
{
    public class DBase : DbContext
    {
        public DbSet <Operation> Operations { get; set; }
        public DbSet <Category> Categories { get; set; }
        public DbSet <Type> Types { get; set; }

                                                
        //public DBase()
        //{
        //    Database.EnsureCreated();
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=BudgetPlaner.db");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
