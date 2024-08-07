using AutoMapper;
using MediatR;
using MyPortfolioProject.Application.DTOs;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class GetMeetingByIdUseCaseHandler : IRequestHandler<GetMeetingByIdUseCase, MeetingDto>
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMapper _mapper;

        public GetMeetingByIdUseCaseHandler(IMeetingRepository meetingRepository, IMapper mapper)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
        }

        public async Task<MeetingDto> Handle(GetMeetingByIdUseCase request, CancellationToken cancellationToken)
        {
            var meeting = await _meetingRepository.GetByIdAsync(request.Id);
            return _mapper.Map<MeetingDto>(meeting);
        }
    }
}
