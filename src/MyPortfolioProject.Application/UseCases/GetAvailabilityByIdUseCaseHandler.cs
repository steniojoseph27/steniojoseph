using AutoMapper;
using MediatR;
using MyPortfolioProject.Application.DTOs;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class GetAvailabilityByIdUseCaseHandler : IRequestHandler<GetAvailabilityByIdUseCase, AvailabilityDto>
    {
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly IMapper _mapper;

        public GetAvailabilityByIdUseCaseHandler(IAvailabilityRepository availabilityRepository, IMapper mapper)
        {
            _availabilityRepository = availabilityRepository;
            _mapper = mapper;
        }

        public async Task<AvailabilityDto> Handle(GetAvailabilityByIdUseCase request, CancellationToken cancellationToken)
        {
            var availability = await _availabilityRepository.GetByIdAsync(request.Id);
            return _mapper.Map<AvailabilityDto>(availability);
        }
    }
}
