
using AutoMapper;
using MediatR;
using MyPortfolioProject.Application.DTOs;
using MyPortfolioProject.Core.Entities;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class ScheduleMeetingUseCaseHandler : IRequestHandler<ScheduleMeetingUseCase, MeetingDto>
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMapper _mapper;

        public ScheduleMeetingUseCaseHandler(IMeetingRepository meetingRepository, IMapper mapper)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
        }

        public async Task<MeetingDto> Handle(ScheduleMeetingUseCase request, CancellationToken cancellationToken)
        {
            var meeting = _mapper.Map<Meeting>(request.Meeting);
            var createdMeeting = await _meetingRepository.AddAsync(meeting);
            return _mapper.Map<MeetingDto>(createdMeeting);
        }
    }
}