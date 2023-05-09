using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVCNew.Models;

namespace SalesWebMVCNew.Data
{
    public class SalesWebMVCNewContext : DbContext
    {

        public SalesWebMVCNewContext (DbContextOptions<SalesWebMVCNewContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebMVCNew.Models.Department> Department { get; set; } = default!;
    }
}
