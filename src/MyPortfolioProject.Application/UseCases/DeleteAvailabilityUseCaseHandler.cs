using MediatR;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class DeleteAvailabilityUseCaseHandler : IRequestHandler<DeleteAvailabilityUseCase>
    {
        private readonly IAvailabilityRepository _availabilityRepository;

        public DeleteAvailabilityUseCaseHandler(IAvailabilityRepository availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }

        public async Task<Unit> Handle(DeleteAvailabilityUseCase request, CancellationToken cancellationToken)
        {
            var availability = await _availabilityRepository.GetByIdAsync(request.Id);
            if (availability != null)
            {
                await _availabilityRepository.DeleteAsync(availability);
            }
            return Unit.Value;
        }

        Task IRequestHandler<DeleteAvailabilityUseCase>.Handle(DeleteAvailabilityUseCase request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
