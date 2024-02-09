using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ListEmployees1.Models;

namespace ListEmployees1.Data
{
    public class ListEmployees1Context : DbContext
    {
        public ListEmployees1Context (DbContextOptions<ListEmployees1Context> options)
            : base(options)
        {
        }

        public DbSet<ListEmployees1.Models.Employee> Employee { get; set; } = default!;
    }
}
