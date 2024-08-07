using AutoMapper;
using MediatR;
using MyPortfolioProject.Application.DTOs;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class GetMeetingsForUserUseCase : IRequest<IEnumerable<MeetingDto>>
    {
        public Guid UserId { get; set; }
    }
}
