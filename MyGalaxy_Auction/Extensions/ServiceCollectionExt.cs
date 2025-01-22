using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyGalaxy_Auction_Business.Abraction;
using MyGalaxy_Auction_Business.Concrete;
using MyGalaxy_Auction_Core.MailHelper;
using MyGalaxy_Auction_Core.Models;
using MyGalaxy_Auction_Data_Access.Context;
using MyGalaxy_Auction_Data_Access.Models;

namespace MyGalaxy_Auction.Extensions
{
    public static class ServiceCollectionExt
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services,IConfiguration configuration)
        {
            #region services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IBidService, BidService>();
            services.AddScoped<IMailService,MailService>();
            services.AddScoped<IPaymentHistoryService,PaymentHistoryService>();
            services.AddScoped(typeof(ApiResponse));
            #endregion
            return services;
        }
       


    }
}
