using ApplyBuddy.Application.Features.JobApplications.Queries.GetJobApplication;
using ApplyBuddy.Application.Features.JobApplications.Queries.GetJobApplicationList;
using ApplyBuddy.Application.Features.DTOs;
using ApplyBuddy.Domain.Aggregates.JobApplication;
using ApplyBuddy.Domain.Aggregates.Position;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplyBuddy.Application.Features.JobApplications.Commands.Create;
using ApplyBuddy.Application.Features.JobApplications.Commands.Update;
using ApplyBuddy.Application.Features.JobApplications.Commands.Delete;

namespace ApplyBuddy.Application.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Job Application Queries
        CreateMap<JobApplication, JobApplicationListVm>();
        CreateMap<JobApplication, JobApplicationDetailVm>();
        CreateMap<Position, PositionDto>().ReverseMap();
        CreateMap<UserTask, TaskListDto>().ReverseMap();
        // Job Application Commands
        CreateMap<JobApplication, CreateJobApplicationCommand>().ReverseMap();
        CreateMap<JobApplication, UpdateJobApplicationCommand>().ReverseMap();
        CreateMap<JobApplication, DeleteJobApplicationCommand>().ReverseMap();

        // Positions Queries


        // Application Task Queries


        
    }

}
