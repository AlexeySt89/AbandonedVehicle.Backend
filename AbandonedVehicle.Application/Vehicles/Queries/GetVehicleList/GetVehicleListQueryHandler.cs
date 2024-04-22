using AbandonedVehicle.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AbandonedVehicle.Application.Vehicles.Queries.GetVehicleList
{
    public class GetVehicleListQueryHandler : IRequestHandler<GetVehicleListQuery, VehicleListVm>
    {
        private readonly IVehicleDbContext _context;
        private readonly IMapper _mapper;

        public GetVehicleListQueryHandler(IVehicleDbContext context, IMapper mapper)
            => (_context, _mapper) = (context, mapper);

        public async Task<VehicleListVm> Handle(GetVehicleListQuery request, CancellationToken cancellationToken)
        {
            var vehiclesQuery = await _context.Vehicles
                .Where(vehicle => vehicle.UserId == request.UserId)
                .ProjectTo<VehicleLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new VehicleListVm { Vehicles = vehiclesQuery };
        }
    }
}
