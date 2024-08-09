using AutoMapper;
using MediatR;
using MyPortfolioProject.Application.DTOs;
using MyPortfolioProject.Core.Entities;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class CreateAvailabilityUseCase : IRequest<AvailabilityDto>
    {
        public AvailabilityDto Availability { get; set; }
    }
}
