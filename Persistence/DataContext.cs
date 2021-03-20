﻿using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOptions> ProductOptions { get; set; }
    }
}
