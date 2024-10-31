using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyGalaxy_Auction_Data_Access.Domain;
using MyGalaxy_Auction_Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGalaxy_Auction_Data_Access.Context
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options):base(options) 
        { 
        }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<PaymentHistory> PaymentHistory { get; set; }
        public DbSet<Vehicle> Vehicle {  get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
