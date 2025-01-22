using Microsoft.EntityFrameworkCore;
using MyGalaxy_Auction_Business.Abraction;
using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_Core.Models;
using MyGalaxy_Auction_Data_Access.Context;
using MyGalaxy_Auction_Data_Access.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGalaxy_Auction_Business.Concrete
{
    public class PaymentHistoryService : IPaymentHistoryService
    {
        private readonly ApiResponse _apiResponse;
        private readonly ApplicationDbContext _context;

        public PaymentHistoryService(ApiResponse apiResponse,ApplicationDbContext applicationDbContext)
        {
            _apiResponse = apiResponse;
            _context = applicationDbContext;
        }

        public async Task<ApiResponse> CheckIsStatusForAuction(string userId, int vehicleId)
        {
            var obj = await _context.PaymentHistory.FirstOrDefaultAsync(x => x.UserId == userId && x.VehicleId == vehicleId && x.IsActive == true);
            if (obj==null)
            {
                _apiResponse.IsSucces = false;
                return _apiResponse;
            }
            _apiResponse.IsSucces=true;
            return _apiResponse;
        }

        public async Task<ApiResponse> CreatePaymentHistory(CreatePaymentHistoryDTO models)
        {
            if (models == null)
            {
                _apiResponse.IsSucces = false;
                _apiResponse.ErrorMessages.Add("Girilen değerler eksik veya boş");
                _apiResponse.StatusCode=System.Net.HttpStatusCode.BadRequest;
                return _apiResponse;
            }
            var result = new PaymentHistory()
            {
                IsActive = true,
                PayDate = DateTime.Now,
                ClientSecret = models.ClientSecret,
                StripePaymentInentId = models.StripePaymentInentId,
                VehicleId = models.VehicleId,
                UserId = models.UserId
            };
            _context.PaymentHistory.Add(result);
            if (await _context.SaveChangesAsync() > 0)
            {
                _apiResponse.IsSucces = true;
                _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                _apiResponse.Result = result;
                return _apiResponse;
            }
            _apiResponse.IsSucces = false;
            _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            return _apiResponse;
        }
    }
}
