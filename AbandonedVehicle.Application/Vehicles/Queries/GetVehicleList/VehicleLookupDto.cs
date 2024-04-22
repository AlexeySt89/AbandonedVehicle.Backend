using AbandonedVehicle.Application.Common.Mappings;
using AbandonedVehicle.Domain;
using AutoMapper;

namespace AbandonedVehicle.Application.Vehicles.Queries.GetVehicleList
{
    public class VehicleLookupDto : IMapWith<Vehicle>
    {
        public Guid Id { get; set; }
        public string Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Vehicle, VehicleLookupDto>()
                .ForMember(noteDto => noteDto.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Address,
                    opt => opt.MapFrom(note => note.Address));
        }
    }
}
