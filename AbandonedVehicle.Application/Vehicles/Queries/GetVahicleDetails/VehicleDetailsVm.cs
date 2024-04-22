using AbandonedVehicle.Application.Common.Mappings;
using AbandonedVehicle.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbandonedVehicle.Application.Vehicles.Queries.GetVahicleDetails
{
    public class VehicleDetailsVm : IMapWith<Vehicle>
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Vehicle, VehicleDetailsVm>()
                .ForMember(vehicleVM => vehicleVM.Address,
                    opt => opt.MapFrom(vehicle => vehicle.Address))
                .ForMember(vehicleVM => vehicleVM.Description,
                    opt => opt.MapFrom(vehicle => vehicle.Description))
                .ForMember(vehicleVM => vehicleVM.Id,
                    opt => opt.MapFrom(vehicle => vehicle.Id))
                .ForMember(vehicleVM => vehicleVM.CreationDate,
                    opt => opt.MapFrom(vehicle => vehicle.CreationDate))
                .ForMember(vehicleVM => vehicleVM.EditDate,
                    opt => opt.MapFrom(vehicle => vehicle.EditDate));
        }
    }
}
