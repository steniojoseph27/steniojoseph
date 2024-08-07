using AutoMapper;
using MediatR;
using MyPortfolioProject.Application.DTOs;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class GetMeetingsForUserUseCaseHandler : IRequestHandler<GetMeetingsForUserUseCase, IEnumerable<MeetingDto>>
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMapper _mapper;

        public GetMeetingsForUserUseCaseHandler(IMeetingRepository meetingRepository, IMapper mapper)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MeetingDto>> Handle(GetMeetingsForUserUseCase request, CancellationToken cancellationToken)
        {
            var meetings = await _meetingRepository.GetMeetingsForUserAsync(request.UserId);
            return _mapper.Map<IEnumerable<MeetingDto>>(meetings);
        }
    }
}
