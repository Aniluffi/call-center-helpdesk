using CallCenterHelpdesk.Data.Configs;
using CallCenterHelpdesk.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenterHelpdesk.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }


        public DataContext(DbContextOptions<DataContext> options):base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RequestConfig());
        }
    }
}
