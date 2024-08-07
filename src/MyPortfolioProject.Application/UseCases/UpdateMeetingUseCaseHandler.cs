using AutoMapper;
using MediatR;
using MyPortfolioProject.Application.DTOs;
using MyPortfolioProject.Core.Entities;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class UpdateMeetingUseCaseHandler : IRequestHandler<UpdateMeetingUseCase>
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMapper _mapper;

        public UpdateMeetingUseCaseHandler(IMeetingRepository meetingRepository, IMapper mapper)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMeetingUseCase request, CancellationToken cancellationToken)
        {
            var meeting = _mapper.Map<Meeting>(request.Meeting);
            await _meetingRepository.UpdateAsync(meeting);
            return Unit.Value;
        }
    }
}
