using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGalaxy_Auction_Business.Abraction;
using MyGalaxy_Auction_Business.Dtos;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace MyGalaxy_Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentHistoryController : ControllerBase
    {
        private readonly IPaymentHistoryService _paymenHistoryService;

        public PaymentHistoryController(IPaymentHistoryService paymentHistoryService)
        {
            _paymenHistoryService = paymentHistoryService;
        }
        [HttpPost("CreatePaymentHistor")]
        public async Task<IActionResult> CreatePaymentHistory(CreatePaymentHistoryDTO models)
        {
            var result=await _paymenHistoryService.CreatePaymentHistory(models);
            if (result.IsSucces == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("CheckIsStatusForAuction")]
        public async Task<IActionResult> CheckIsStatusForAuction(string userId, int vehicleId)
        {
            var result=await _paymenHistoryService.CheckIsStatusForAuction(userId, vehicleId);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
