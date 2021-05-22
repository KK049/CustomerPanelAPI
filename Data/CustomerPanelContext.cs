using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerPanel.Models;

namespace CustomerPanel.Data
{
    public class CustomerPanelContext : DbContext
    {
        public CustomerPanelContext (DbContextOptions<CustomerPanelContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerPanel.Models.Customers> Customers { get; set; }
    }
}
