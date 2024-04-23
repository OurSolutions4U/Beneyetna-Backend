using Beneyetna.DataContracts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beneyetna.DataContracts.Context
{
    public class BeneyetnaContext : DbContext, IBeneyetnaContext, IDisposable
    {
        public virtual DbSet<User> Users { set; get; }
        public virtual DbSet<AccessToken> AccessTokens { set; get; }

        public BeneyetnaContext()
        {
        }

        public BeneyetnaContext(DbContextOptions<BeneyetnaContext> options) : base(options)
        {

        }
    }
}
