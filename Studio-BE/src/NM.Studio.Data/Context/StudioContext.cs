using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NM.Studio.Domain.Entities.Events;
using NM.Studio.Domain.Entities.Locations;
using NM.Studio.Domain.Entities.Photos;
using NM.Studio.Domain.Entities.Services;
using NM.Studio.Domain.Entities.Users;
using NM.Studio.Domain.Entities.Weddings;

namespace NM.Studio.Data.Context
{
    public class StudioContext : BaseDbContext
    {
        public StudioContext(DbContextOptions<StudioContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        
        public DbSet<Photo> Photos { get; set; }
        
        public DbSet<Service> Services { get; set; }
        
        public DbSet<Location> Locations { get; set; }
        
        public DbSet<City> Cities { get; set; }
        
        public DbSet<Country> Countries { get; set; }
        
        public DbSet<Wedding> Weddings { get; set; }

        public DbSet<Role> Roles { get; set; }
        
        public DbSet<User> Users { get; set; }

    }
}
