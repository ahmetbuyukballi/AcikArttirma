using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.IdentityModel.Tokens;
using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGalaxy_Auction_Business.Abraction
{
    public interface IBidService
    {
        Task<ApiResponse> CreateBid(CreateBidDtos models);
        Task<ApiResponse> UpdateBid(int BidId,UpdateBidDtos models);
        Task<ApiResponse> GetBidById (int BidId);
        Task<ApiResponse> CancelBid (int BidIdd);
        Task<ApiResponse> AutomaticallyCreateBidId(CreateBidDtos models);
        Task<ApiResponse> GetBidByVehicleId(int VehicleId);

    }
}
