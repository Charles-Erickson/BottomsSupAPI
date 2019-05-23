﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BottomsSupAPI.Models
{
    public class TokensContext : DbContext
    {
        
            public TokensContext(DbContextOptions<TokensContext> options)
                : base(options)
            {
            }

            public DbSet<TokensItem> TokensItems { get; set; }

        }
}