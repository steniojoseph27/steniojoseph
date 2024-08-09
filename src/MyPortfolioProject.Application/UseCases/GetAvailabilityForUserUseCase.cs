using AutoMapper;
using MediatR;
using MyPortfolioProject.Application.DTOs;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class GetAvailabilityForUserUseCase : IRequest<IEnumerable<AvailabilityDto>>
    {
        public Guid UserId { get; set; }
    }
}
