﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pride_.Domain;

namespace Pride_
{
    public class PrideMoreContext : IdentityDbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Professional> professionals { get; set; }
        public DbSet<Patient> pacients { get; set; }
        public DbSet<ProfessionalType> ProfessionalTypes { get; set; }
        public PrideMoreContext(DbContextOptions<PrideMoreContext> options) : base(options)
        {

        }
    }
}