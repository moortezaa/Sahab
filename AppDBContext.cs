using Sahab_Desktop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Sahab_Desktop
{
    class AppDBContext : DbContext
    {
        public DbSet<Task> Categories { get; set; }
    }
}
