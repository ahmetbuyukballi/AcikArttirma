 using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyGalaxy_Auction_Data_Access.Context;
using MyGalaxy_Auction_Data_Access.Models;

namespace MyGalaxy_Auction.Extensions
{
    public static class PercictenceExtentensionLayer
    {
        public static IServiceCollection AddDbContextLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region services
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            #endregion
            return services;
        }
    }
}
