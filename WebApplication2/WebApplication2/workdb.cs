using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication2.Model;

class workdb : DbContext
{
    public workdb(DbContextOptions<workdb> options)
    : base(options) { }

    public DbSet<work> works => Set<work>();
}