using AutoMapper;
using MediatR;
using MyPortfolioProject.Application.DTOs;
using MyPortfolioProject.Core.Entities;
using MyPortfolioProject.Core.Interfaces;

namespace MyPortfolioProject.Application.UseCases
{
    public class UpdateMeetingUseCase : IRequest
    {
        public MeetingDto Meeting { get; set; }
    }
}
