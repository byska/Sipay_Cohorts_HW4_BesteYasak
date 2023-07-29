using Microsoft.EntityFrameworkCore;
using Sipay_Cohorts_HW4.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohorts_HW4.DataAccess.Context
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options):base(options)
        {
            
        }
        public DbSet<Book>Books { get; set; }
    }
}
