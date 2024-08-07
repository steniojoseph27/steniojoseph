using AutoMapper;
using MediatR;
using MyPortfolioProject.Application.DTOs;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class GetMeetingByIdUseCase : IRequest<MeetingDto>
    {
        public Guid Id { get; set; }
    }
}
