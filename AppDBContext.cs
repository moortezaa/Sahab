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
        public AppDBContext()
            :base("SahabConnectionString")
        {
            Database.SetInitializer(new AppDBInitializer());
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Doctrine> Doctrines { get; set; }
        public DbSet<DoctrineRelation> DoctrineRelations { get; set; }
        public DbSet<Frame> Frames { get; set; }
        public DbSet<FrameRelation> FrameRelations { get; set; }
        public DbSet<Them> Thems { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
