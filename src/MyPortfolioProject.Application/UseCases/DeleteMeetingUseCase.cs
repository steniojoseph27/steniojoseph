using MediatR;

namespace MyPortfolioProject.Application.UseCases
{
    public class DeleteMeetingUseCase : IRequest
    {
        public Guid Id { get; set; }
    }
}
