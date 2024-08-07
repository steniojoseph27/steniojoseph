using MediatR;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class DeleteMeetingUseCaseHandler : IRequestHandler<DeleteMeetingUseCase>
    {
        private readonly IMeetingRepository _meetingRepository;

        public DeleteMeetingUseCaseHandler(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public async Task<Unit> Handle(DeleteMeetingUseCase request, CancellationToken cancellationToken)
        {
            var meeting = await _meetingRepository.GetByIdAsync(request.Id);
            if (meeting != null)
            {
                await _meetingRepository.DeleteAsync(meeting);
            }
            return Unit.Value;
        }

        Task IRequestHandler<DeleteMeetingUseCase>.Handle(DeleteMeetingUseCase request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
