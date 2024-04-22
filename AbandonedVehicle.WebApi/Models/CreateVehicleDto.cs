using AbandonedVehicle.Application.Common.Mappings;
using AbandonedVehicle.Application.Vehicles.Commands.CreateVehicle;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace AbandonedVehicle.WebApi.Models
{
    public class CreateVehicleDto : IMapWith<CreateVehicleCommand>
    {
        [Required]
        public string Address { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateVehicleDto, CreateVehicleCommand>()
                .ForMember(vehicleCommand => vehicleCommand.Address,
                    opt => opt.MapFrom(vehicleDto => vehicleDto.Address))
                .ForMember(vehicleCommand => vehicleCommand.Description,
                    opt => opt.MapFrom(vehicleDto => vehicleDto.Description));

        }
    }
}
