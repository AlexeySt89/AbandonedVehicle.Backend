using AbandonedVehicle.Application.Common.Exceptions;
using AbandonedVehicle.Application.Interfaces;
using AbandonedVehicle.Domain;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AbandonedVehicle.Application.Vehicles.Queries.GetVahicleDetails
{
    public class GetVehicleDetailsQueryHandler : IRequestHandler<GetVehicleDetailsQuery, VehicleDetailsVm>
    {
        private readonly IVehicleDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetVehicleDetailsQueryHandler(IVehicleDbContext dbContext, IMapper mapper)
            => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<VehicleDetailsVm> Handle(GetVehicleDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Vehicles.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Vehicle), request);
            }

            return _mapper.Map<VehicleDetailsVm>(entity);
        }

    }
}
