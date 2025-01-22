using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MyGalaxy_Auction_Business.Abraction;
using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_Core.MailHelper;
using MyGalaxy_Auction_Core.Models;
using MyGalaxy_Auction_Data_Access.Context;
using MyGalaxy_Auction_Data_Access.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyGalaxy_Auction_Business.Concrete
{
    public class BidService : IBidService
    { private readonly ApplicationDbContext _context;
       private readonly ApiResponse _apiResponse;
        private readonly IMailService _mailService;
        public BidService(ApplicationDbContext context,ApiResponse apiResponse,IMailService mailService) 
        { 
            _context = context;
            _apiResponse=apiResponse;
            _mailService=mailService;
        }
        public async Task<ApiResponse> AutomaticallyCreateBidId(CreateBidDtos models)
        {
            var isPaid = await CheckIsPaidAuction(models.UserId, models.VehicleId);
            if (!isPaid)
            {
                _apiResponse.IsSucces = false;
                _apiResponse.ErrorMessages.Add("Ödeme geçmişi bulunamadı.");
                _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return _apiResponse;
            }
            var result = await _context.Bids.Where(x => x.VehicleId == models.VehicleId && x.Vehicle.IsActive == true).OrderByDescending(x=>x.BidAmount).ToListAsync();
            if (result.Count == 0)
            {
                _apiResponse.IsSucces = false;
                _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return _apiResponse;
            }
            var amount = result[0].BidAmount + (result[0].BidAmount * 10 / 100);
            Bid bid = new()
            {
                BidAmount = amount,
                BidDate = DateTime.Now,
            };
            _context.Bids.Add(bid);
            if (_context.SaveChanges() > 0)
            {
                _apiResponse.IsSucces = true;
                _apiResponse.Result = bid;
                _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return _apiResponse;
            }

            _apiResponse.IsSucces = false;
            _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            return _apiResponse;

        }

        public Task<ApiResponse> CancelBid(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> CreateBid(CreateBidDtos models)
        {
            if (models == null)
            {
                _apiResponse.IsSucces = false;
                _apiResponse.ErrorMessages.Add("Teklif bulunamadı");
                _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return _apiResponse;
            }
            var result = await CheckVehicle(models.VehicleId);
            var obj = await CheckIsPaidAuction(models.UserId, models.VehicleId);
            if (result.IsSucces==true)
            {
                Bid bid = new()
                {
                    BidAmount = models.BidAmount,
                    BidStatus = models.BidStatus,
                    BidDate = models.BidDate,
                    UserId = models.UserId,
                    VehicleId = models.VehicleId,
                };
                _context.Bids.Add(bid);
                if ( _context.SaveChanges() > 0)
                {
                    bid = _context.Bids.Include(b => b.User).FirstOrDefault(b => b.UserId == bid.UserId);

                    _mailService.SendEmail("Teklif başarıyla oluşturuldu", "Verdiğiniz teklif:" + bid.BidAmount, bid.User.Email);
                    _apiResponse.IsSucces = true;
                    _apiResponse.Result = bid;
                    _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    return _apiResponse;
                }
                if (bid == null)
                {
                    _apiResponse.IsSucces = false;
                    _apiResponse.ErrorMessages.Add("Teklif geçerli değil");
                    _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    return _apiResponse;
                }
                _apiResponse.IsSucces = false;
                _apiResponse.ErrorMessages.Add("Teklif geçerli değil");
                _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return _apiResponse;
            }
            _apiResponse.IsSucces = false;
            _apiResponse.ErrorMessages.Add("Araç aktif değil");
            _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            return _apiResponse;
        }

        public async Task<ApiResponse> GetBidById(int id)
        {
            var bidId=await _context.Bids.Where(x=>x.BidId==id).FirstOrDefaultAsync();
            if(bidId == null)
            {
                _apiResponse.IsSucces = false;
                _apiResponse.ErrorMessages.Add("Böyle bir teklif yok.");
                _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return _apiResponse;
            }
            _apiResponse.IsSucces = true;
            _apiResponse.Result = bidId;
            _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
            return _apiResponse;
        }

        public async Task<ApiResponse> GetBidByVehicleId(int VehicleId)
        {
           var vehicleBids=await _context.Bids.Where(x=>x.VehicleId==VehicleId).FirstOrDefaultAsync();
            if (vehicleBids == null) 
            {
                _apiResponse.IsSucces = false;
                _apiResponse.ErrorMessages.Add("Bu araça ait teklif yok.");
                _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return _apiResponse;
            }
            _apiResponse.IsSucces = true;
            _apiResponse.Result = vehicleBids;
            _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
            return _apiResponse;
        }

        public async Task<ApiResponse> UpdateBid(int BidId, UpdateBidDtos models)
        {
            //update eden kullanıcı en son verdiği teklifin üzerine çıkmalıdır.,
            var bid=await _context.Bids.FirstOrDefaultAsync(x=>x.BidId==BidId);
            if(bid == null)
            {
                _apiResponse.IsSucces = false;
                _apiResponse.ErrorMessages.Add("Teklif bulunamadı.");
                _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return _apiResponse;
            }
            if (models.BidAmount > bid.BidAmount)
            {
                bid = new()
                {
                    BidAmount = models.BidAmount,
                    BidStatus = models.BidStatus,
                    BidDate = models.BidDate,
                    UserId = models.UserId,
                    VehicleId = models.VehicleId,
                };
                
                _context.Bids.Update(bid);
                if (_context.SaveChanges() > 0)
                {
                    _apiResponse.IsSucces = true;
                    _apiResponse.Result = bid;
                    _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    return _apiResponse;
                }
                _apiResponse.IsSucces = false;
                _apiResponse.ErrorMessages.Add("Teklif bulunamadı.");
                _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return _apiResponse;
            }
            _apiResponse.IsSucces = false;
            _apiResponse.ErrorMessages.Add("Teklif bulunamadı.");
            _apiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
            return _apiResponse;

        }

        private async Task<ApiResponse> CheckVehicle(int VehicleId)
        {
            var vehicle=await _context.Vehicle.Where(x=>x.VehicleId==VehicleId && x.EndTime>=DateTime.Now).FirstOrDefaultAsync();
            bool result = vehicle.IsActive;
            if (result == true)
            {
                _apiResponse.IsSucces = true;
                _apiResponse.Result=vehicle;
                return _apiResponse;
            }
            _apiResponse.IsSucces = false;
            return _apiResponse;

        }
        private async Task<bool> CheckIsPaidAuction(string userId,int vehicleId)
        {
            var obj = await _context.PaymentHistory.Where(x => x.UserId == userId && x.VehicleId == vehicleId && x.IsActive == true).FirstOrDefaultAsync();
            if (obj != null)
            {
                return true;
            }
            return false;
        }
    }
}
