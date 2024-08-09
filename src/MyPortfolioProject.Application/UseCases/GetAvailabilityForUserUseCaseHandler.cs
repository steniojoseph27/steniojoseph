using AutoMapper;
using MediatR;
using MyPortfolioProject.Application.DTOs;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class GetAvailabilityForUserUseCaseHandler : IRequestHandler<GetAvailabilityForUserUseCase, IEnumerable<AvailabilityDto>>
    {
        private readonly IAvailabilityRepository _availabilityRepository;
        private readonly IMapper _mapper;

        public GetAvailabilityForUserUseCaseHandler(IAvailabilityRepository availabilityRepository, IMapper mapper)
        {
            _availabilityRepository = availabilityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AvailabilityDto>> Handle(GetAvailabilityForUserUseCase request, CancellationToken cancellationToken)
        {
            var availabilities = await _availabilityRepository.GetAvailabilityForUserAsync(request.UserId);
            return _mapper.Map<IEnumerable<AvailabilityDto>>(availabilities);
        }
    }
}
