using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOList.Models;

namespace TODOList.Data
{
    public class ApiDbContext : IdentityDbContext

    {
        public DbSet<TODOList.Models.Account> Accounts { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Homework> Homework { get; set; }

        public DbSet<TODOItem> TODOItem { get; set; }

    }
}
