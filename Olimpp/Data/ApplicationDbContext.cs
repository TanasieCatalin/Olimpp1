using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Olimpp.Models;
using Olimpp.Models.ViewModels;

namespace Olimpp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BookingTable> BookingTable { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<MovieDetalies> MovieDetalies { get; set; }
        //public DbSet<ApplicationUser> ApplicationUser { get; set; }
        //public DbSet<Aplicatie> Aplicatie  { get; set; }



        public DbSet<Olimpp.Models.ViewModels.MovieDetaliesViewmodel> MovieDetaliesViewmodel { get; set; }
        public DbSet<Olimpp.Models.ViewModels.BookNowViewModel> BookNowViewModel { get; set; }
        public object IdentityUser { get; internal set; }
    
     
    }
}
