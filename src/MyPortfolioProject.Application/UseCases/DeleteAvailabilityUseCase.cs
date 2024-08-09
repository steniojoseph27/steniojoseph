using MediatR;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class DeleteAvailabilityUseCase : IRequest
    {
        public Guid Id { get; set; }
    }
}
