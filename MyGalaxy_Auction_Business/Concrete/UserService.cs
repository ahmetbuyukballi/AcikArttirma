using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using MyGalaxy_Auction_Business.Abraction;
using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_Core.Models;
using MyGalaxy_Auction_Data_Access.Context;
using MyGalaxy_Auction_Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MyGalaxy_Auction_Data_Access.Enum;
using Microsoft.SqlServer.Server;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace MyGalaxy_Auction_Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ApiResponse _apiResponse;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string secretKey;

        public UserService(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager, IMapper mapper, ApiResponse apiResponse, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _context = applicationDbContext;
            _userManager = userManager;
            _mapper = mapper;
            _apiResponse = apiResponse;
            _roleManager = roleManager;
            secretKey = configuration.GetValue<string>("SecretKey:JwtKey");
        }

        public async Task<ApiResponse> Login(LoginRequestDtos models)
        {
            ApplicationUser user = _context.ApplicationUser.FirstOrDefault(x => x.UserName == models.UserName);
            if(user!=null) 
            {
                bool IsValid = await _userManager.CheckPasswordAsync(user,models.Password);
                if (!IsValid)
                {
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    _apiResponse.ErrorMessages.Add("You entry information is not correct");
                    _apiResponse.IsSucces = false;
                    return _apiResponse;
                }
                var role = await _userManager.GetRolesAsync(user);
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(secretKey);
                SecurityTokenDescriptor securityTokenDescriptor = new()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.Id),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Role,role.FirstOrDefault()),
                        new Claim("fullname",user.FullName),
                    }),
                    
                    Expires=DateTime.UtcNow.AddDays(1),
                    SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)

                };
                SecurityToken token=tokenHandler.CreateToken(securityTokenDescriptor);
                LoginResponseModels loginResponseModel = new()
                {
                    Email = user.Email,
                    Token = tokenHandler.WriteToken(token),
                };
                _apiResponse.Result= loginResponseModel;
                _apiResponse.IsSucces = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return _apiResponse;
                
                
                    

            }
            _apiResponse.IsSucces= false;
            _apiResponse.StatusCode = HttpStatusCode.BadRequest;
            _apiResponse.ErrorMessages.Add("Ooopss!! something went wrong");
            return _apiResponse;
        }

        public async Task<ApiResponse> Register(RegisterRequestDtos models)
        {
            var userName = _context.ApplicationUser.FirstOrDefault(x => x.UserName.ToLower ()== models.UserName.ToLower());
            if (userName != null)
            {
                _apiResponse.StatusCode=HttpStatusCode.BadRequest;
                _apiResponse.IsSucces = false;
                _apiResponse.ErrorMessages.Add("User already exits");
                return _apiResponse;
            }
            //var user=_mapper.Map<ApplicationUser>(models);
            ApplicationUser user = new()
            {
                UserName = models.UserName,
                FullName = models.FullName,
                NormalizedEmail = models.UserName.ToUpper(),
                Email = models.UserName,
            };
            var result=await _userManager.CreateAsync(user,models.Password);
            if (result.Succeeded)
            {
                var IsTrue = _roleManager.RoleExistsAsync(UserType.Administrator.ToString()).GetAwaiter().GetResult();//why didn't being await 
                if (!IsTrue)
                {
                    await _roleManager.CreateAsync(new IdentityRole(UserType.Administrator.ToString()));
                    await _roleManager.CreateAsync(new IdentityRole(UserType.Seller.ToString()));
                    await _roleManager.CreateAsync(new IdentityRole(UserType.NormalUser.ToString()));
                    
                }
                if (models.UserType.ToString().ToLower() == UserType.Administrator.ToString().ToLower()) 
                { 
                    await _userManager.AddToRoleAsync(user, UserType.Administrator.ToString());
                }
                if(models.UserType.ToString().ToLower()== UserType.Seller.ToString().ToLower())
                {
                    await _userManager.AddToRoleAsync(user,UserType.Seller.ToString());
                }
                else if(models.UserType.ToString().ToLower() == UserType.NormalUser.ToString().ToLower())
                {
                    await _userManager.AddToRoleAsync(user, UserType.NormalUser.ToString());
                }
                _apiResponse.StatusCode=HttpStatusCode.Created;
                _apiResponse.IsSucces=true;
                return _apiResponse;
            }
            foreach(var errors in result.Errors)
            {
                _apiResponse.ErrorMessages.Add(errors.ToString());
            }
            return _apiResponse;
        }
    }
}
