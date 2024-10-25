using MyGalaxy_Auction_Business.Abraction;
using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGalaxy_Auction_Business.Concrete
{
    public class UserService:IUserService
    {
        public Task<ApiResponse> Login(LoginRequestDtos models)
        {
            
        }
        public Task<ApiResponse> Register(RegisterRequestDtos models)
        {

        }
    }
}
