using Microsoft.EntityFrameworkCore;
using RepoLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Context
{
    public class FunDoContext : DbContext
    {
       
            public FunDoContext(DbContextOptions options) : base(options)
            {
            }
            public DbSet<UserEntity> UserTable { get; set; }
    }
}