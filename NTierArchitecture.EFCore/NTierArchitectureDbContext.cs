﻿using Microsoft.EntityFrameworkCore;
using NTierArchitecture.EFCore.Mapping;
using NTierArchtitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.EFCore
{
    public class NTierArchitectureDbContext:DbContext
    {
        public NTierArchitectureDbContext(DbContextOptions<NTierArchitectureDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mapi Yapmamızın amacı veri tabanında tabloyu oluştururken propertylerini oluşturuyoruz. Migration kısmında dbye kolonların propertyleri ile oluşturuyoruz.
            modelBuilder.ApplyConfiguration(new CustomerMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}