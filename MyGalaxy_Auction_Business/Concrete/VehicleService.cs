using AutoMapper;
using Azure;
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
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ApiResponse _response;
        public VehicleService(ApplicationDbContext context,IMapper mapper,ApiResponse apiResponse)
        {

            _context = context;
            _mapper = mapper;
            _response = apiResponse;
        }
        public async Task<ApiResponse> ChangeVehicleStatus(int VehicleId)
        {
            var result=await _context.Vehicle.FindAsync(VehicleId);
            if (result == null)
            {   
                _response.IsSucces= false;
                return _response;
            }
            result.IsActive = false;
            _response.IsSucces = true;
            await _context.SaveChangesAsync();
            return _response;

        }

        public async Task<ApiResponse> CreateVehice(CreateVehicleDtos models)
        {
            if (models != null)
            {
                var objDto = _mapper.Map<Vehicle>(models);
                if (objDto != null)
                {
                    _context.Vehicle.Add(objDto);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        _response.IsSucces = true;
                        _response.StatusCode = System.Net.HttpStatusCode.Created;
                        _response.Result = models;
                        return _response;
                    }

                }
            }
            _response.IsSucces = false;
            _response.ErrorMessages.Add("Ooopss!!Something went wrong.");
            _response.StatusCode=System.Net.HttpStatusCode.BadRequest;
            return _response;

        }

        public async Task<ApiResponse> DeleteVehicle(int VehicleId)
        {
            var vehicle=_context.Vehicle.FirstOrDefault(x=>x.VehicleId == VehicleId);
            if(vehicle != null)
            {
                _context.Vehicle.Remove(vehicle);
                if(await _context.SaveChangesAsync() > 0)
                {
                    _response.IsSucces = true;
                    _response.Result=vehicle;
                    _response.StatusCode = System.Net.HttpStatusCode.OK;
                    return _response;
                }
            }
            _response.IsSucces=false;
            _response.ErrorMessages.Add("Ooops!!Something went wrong.");
            _response.StatusCode= System.Net.HttpStatusCode.BadRequest;
            return _response;
        }

        public async Task<ApiResponse> GetVehicleById(int VehicleId)
        {
            var vehicle=await _context.Vehicle.FirstOrDefaultAsync(x=>x.VehicleId == VehicleId);
            if (vehicle != null)
            {
                _response.Result= vehicle;
                _response.IsSucces=true;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
                return _response;
            }
            _response.IsSucces=false;
            _response.ErrorMessages.Add("Vehicle was not found.");
            _response.StatusCode=System.Net.HttpStatusCode.BadRequest;
            return _response;
        }

        public async Task<ApiResponse> GetVehicle()
        {
            var vehicle=await _context.Vehicle.Include(x=>x.Seller).ToListAsync();
            if (vehicle != null) 
            {
                _response.Result= vehicle;
                _response.IsSucces=true;
                return _response;

            }
            _response.IsSucces =false;
            return _response;

        }

        public async Task<ApiResponse> UpdateVehicle(int VehicleId, UpdateVehicleDtos models)
        {
           var vehicle=_context.Vehicle.FirstOrDefault(x=>x.VehicleId == VehicleId);
            if(vehicle != null)
            {
                var objDto=_mapper.Map(models,vehicle);
                if ( await _context.SaveChangesAsync() > 0)
                {
                    _response.IsSucces = true;
                    _response.StatusCode= System.Net.HttpStatusCode.OK;
                    _response.Result = objDto;
                    return _response;
                }
            }
            _response.IsSucces=false;
            _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            return _response;

        }
    }
}
