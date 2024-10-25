using MyGalaxy_Auction_Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGalaxy_Auction_Core.Models;

namespace MyGalaxy_Auction_Business.Abraction
{
    public interface IUserService
    {
        Task<ApiResponse> Login(LoginRequestDtos model);
        Task<ApiResponse> Register(RegisterRequestDtos model);
    }
}
