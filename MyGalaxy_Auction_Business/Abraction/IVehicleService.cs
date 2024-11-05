using MyGalaxy_Auction_Business.Dtos;
using MyGalaxy_Auction_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGalaxy_Auction_Business.Abraction
{
    public interface IVehicleService
    {
        Task<ApiResponse> CreateVehice(CreateVehicleDtos models);
        Task<ApiResponse> UpdateVehicle(int VehicleId, UpdateVehicleDtos models);
        Task<ApiResponse> GetVehicle();
        Task<ApiResponse> DeleteVehicle(int VehicleId);
        Task<ApiResponse> GetVehicleById(int VehicleId);
        Task<ApiResponse> ChangeVehicleStatus(int VehicleId);

    }
}
