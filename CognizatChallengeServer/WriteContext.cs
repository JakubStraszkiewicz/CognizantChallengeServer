using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognizatChallengeServer
{
    public class WriteContext : DbContext
    {
        public WriteContext(DbContextOptions options) : base(options) 
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Attempt> Attempts { get; set; }
    }
}
