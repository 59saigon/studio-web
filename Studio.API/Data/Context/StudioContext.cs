using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Entities.Locations;
using Studio.API.Business.Domain.Entities.Photos;
using Studio.API.Business.Domain.Entities.Services;
using Studio.API.Business.Domain.Entities.Users;
using Studio.API.Business.Domain.Entities.Weddings;

namespace Studio.API.Data.Context
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
