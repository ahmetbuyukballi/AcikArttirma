using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using MyGalaxy_Auction_Business.Abraction;
using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_Core.Models;

namespace MyGalaxy_Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidSservice;
        private readonly ApiResponse _apiResponse;
        public BidController(IBidService bidSservice, ApiResponse apiResponse)
        {
            _bidSservice = bidSservice;
            _apiResponse = apiResponse;
        }
        [HttpPost("AutomaticallyCreateBidId")]
        public async Task<IActionResult> AutomaticallyCreateBidId(CreateBidDtos models)
        {
            var result = await _bidSservice.AutomaticallyCreateBidId(models);
            if (result.IsSucces == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPost("CreateBid")]
        public async Task<IActionResult> CreateBid(CreateBidDtos models)
        {
            var result = await _bidSservice.CreateBid(models);
            if (result.IsSucces == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("GetBidById")]
        public async Task<IActionResult> GetBidById(int id)
        {
            var result = await _bidSservice.GetBidById(id);
            if (result.IsSucces == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("GetBidByVehicleId")]
        public async Task<IActionResult> GetBidByVehicleId(int VehicleId)
        {
            var result = await _bidSservice.GetBidByVehicleId(VehicleId);
            if (result.IsSucces == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateBid(int BidId, UpdateBidDtos models)
        {
            var result = await _bidSservice.UpdateBid(BidId, models);
            if (result.IsSucces == false)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
