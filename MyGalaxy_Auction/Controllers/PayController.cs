using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_Core.Models;
using MyGalaxy_Auction_Data_Access.Context;
using Stripe;

namespace MyGalaxy_Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly ApiResponse _apiResponse;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public PayController(ApiResponse apiResponse,IConfiguration configuration,ApplicationDbContext context)
        {
            _apiResponse= apiResponse;
            _configuration= configuration;
            _context= context;
        }
        [HttpPost("Pay")]
        public async Task<ActionResult<ApiResponse>> MakePayment(string userId,int vehicleıd)
        {
            StripeConfiguration.ApiKey=_configuration.GetValue<string>("StripeSettings:SecretKey");
            var amountToBePaid = await _context.Vehicle.FirstOrDefaultAsync(x => x.VehicleId == vehicleıd);
            var options = new PaymentIntentCreateOptions
            {
                Amount = (int)(amountToBePaid.AuctionPrice * 100),
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" }
            };
            var service = new PaymentIntentService();
            var response = service.Create(options);

            CreatePaymentHistoryDTO models = new()
            {
                ClientSecret = response.ClientSecret,
                StripePaymentInentId = response.Id,
                UserId = userId,
                VehicleId = vehicleıd
            };
            _apiResponse.Result = models;
            _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
            return _apiResponse;

        }
    }
}
