using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testmylearning.Model;

namespace testmylearning.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Person> persons { get; set; }
        public DbSet<Transactions> Transaction { get; set; }
     


    }
}
