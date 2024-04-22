using AbandonedVehicle.Application.Common.Mappings;
using AbandonedVehicle.Application.Vehicles.Commands.UpdateVehicle;
using AutoMapper;

namespace AbandonedVehicle.WebApi.Models
{
    public class UpdateVehicleDto : IMapWith<UpdateVehicleCommand>
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateVehicleDto, UpdateVehicleCommand>()
                .ForMember(vehicleCommand => vehicleCommand.Id,
                    opt => opt.MapFrom(vehicleDto => vehicleDto.Id))
                .ForMember(vehicleCommand => vehicleCommand.Address,
                    opt => opt.MapFrom(vehicleDto => vehicleDto.Address))
                .ForMember(vehicleCommand => vehicleCommand.Description,
                    opt => opt.MapFrom(vehicleDto => vehicleDto.Description));
        }
    }
}
