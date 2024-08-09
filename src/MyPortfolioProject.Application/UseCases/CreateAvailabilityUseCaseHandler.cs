using AutoMapper;
using MediatR;
using MyPortfolioProject.Application.DTOs;
using MyPortfolioProject.Core.Entities;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class CreateAvailabilityUseCaseHandler : IRequestHandler<CreateAvailabilityUseCase, AvailabilityDto>
    {
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly IMapper _mapper;

        public CreateAvailabilityUseCaseHandler(IAvailabilityRepository availabilityRepository, IMapper mapper)
        {
            _availabilityRepository = availabilityRepository;
            _mapper = mapper;
        }

        public async Task<AvailabilityDto> Handle(CreateAvailabilityUseCase request, CancellationToken cancellationToken)
        {
            var availability = _mapper.Map<Availability>(request.Availability);
            var createdAvailability = await _availabilityRepository.AddAsync(availability);
            return _mapper.Map<AvailabilityDto>(createdAvailability);
        }
    }
}
