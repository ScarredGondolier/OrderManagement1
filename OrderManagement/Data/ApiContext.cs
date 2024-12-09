using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;
using System.Collections.Generic;

namespace OrderManagement.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        { }

    }
}
