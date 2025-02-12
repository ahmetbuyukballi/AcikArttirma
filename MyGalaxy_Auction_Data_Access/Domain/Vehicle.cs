﻿using MyGalaxy_Auction_Data_Access.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyGalaxy_Auction_Data_Access.Domain
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public string BrandAndModel { get; set; }
        public int ManuFacturingYear { get; set; }
        public string Color { get; set; }
        public decimal EngineCapacity { get; set; }
        public decimal Price { get; set; }
        public int Millage { get; set; }
        public string PlateNumber { get; set; }
        public double AuctionPrice { get; set; }
        public string AdditionalInformation { get; set; }
        public DateTime StartTime { get; set; }=DateTime.Now;
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }  =true;
        public string Image {  get; set; }

        public string SellerId { get; set; }
        [JsonIgnore]
        public ApplicationUser Seller { get; set; }
        public ICollection<Bid> Bids { get; set; }

    }
}
