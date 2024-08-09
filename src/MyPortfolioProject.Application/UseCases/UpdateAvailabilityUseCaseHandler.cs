using AutoMapper;
using MediatR;
using MyPortfolioProject.Application.DTOs;
using MyPortfolioProject.Core.Entities;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class UpdateAvailabilityUseCaseHandler : IRequestHandler<UpdateAvailabilityUseCase>
    {
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly IMapper _mapper;

        public UpdateAvailabilityUseCaseHandler(IAvailabilityRepository availabilityRepository, IMapper mapper)
        {
            _availabilityRepository = availabilityRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAvailabilityUseCase request, CancellationToken cancellationToken)
        {
            var availability = _mapper.Map<Availability>(request.Availability);
            await _availabilityRepository.UpdateAsync(availability);
            return Unit.Value;
        }

        Task IRequestHandler<UpdateAvailabilityUseCase>.Handle(UpdateAvailabilityUseCase request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
