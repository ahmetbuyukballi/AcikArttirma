using Microsoft.AspNetCore.Mvc;
using MyGalaxy_Auction_Business.Abraction;
using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_Core.Models;

namespace MyGalaxy_Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleControllers : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly ApiResponse _apiResponse;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public VehicleControllers(IVehicleService vehicleService, ApiResponse apiResponse, IWebHostEnvironment webHostEnvironment)
        {
            _vehicleService = vehicleService;
            _apiResponse = apiResponse;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CreateVehicleDtos models)
        {
            if (ModelState.IsValid)
            {
                if (models.File == null || models.File.Length == 0)
                {
                    return BadRequest();
                }
                var uploadFolders = Path.Combine(_webHostEnvironment.ContentRootPath, "Images");
                var filename = $"{Guid.NewGuid()}{Path.GetExtension(models.File.FileName)}";
                string filePath = Path.Combine(uploadFolders, filename);

                models.Image = filename;

                var result = await _vehicleService.CreateVehice(models);
                if (result.IsSucces == true)
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        await models.File.CopyToAsync(fs);
                    }
                    return Ok(result);
                }
            }
            return BadRequest();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateVehicleDtos models, [FromQuery] int VehicleId)
        {
            var result = await _vehicleService.UpdateVehicle(VehicleId, models);
            if (result.IsSucces == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] int VehicleId)
        {
            var result = await _vehicleService.DeleteVehicle(VehicleId);
            if (result.IsSucces == true)
            {
                return Ok(result);
            }
            return BadRequest();

        }
        [HttpGet("GetVehicles")]
        public async Task<IActionResult> GetAllVehicle()
        {
            var result = await _vehicleService.GetVehicle();
            if (result.IsSucces == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("{VehicleId}")]
        public async Task<IActionResult> GetVehicleById([FromRoute] int VehicleId)
        {
            var result = await _vehicleService.GetVehicleById(VehicleId);
            if (result.IsSucces == true)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut("{VehicleId}")]
        public async Task<IActionResult> ChangesVehicleStatus([FromRoute] int VehicleId)
        {
            var result = await _vehicleService.ChangeVehicleStatus(VehicleId);
            if (result.IsSucces)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
