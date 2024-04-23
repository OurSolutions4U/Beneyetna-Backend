using Beneyetna.DataContracts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beneyetna.DataContracts.Context
{
    internal interface IBeneyetnaContext : IDisposable
    {
        DbSet<User> Users { get; set; }
    }
}
