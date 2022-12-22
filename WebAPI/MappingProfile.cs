using AutoMapper;
using Guliver_Backend_Assignment.ApplicationCore.DTOs;
using Guliver_Backend_Assignment.Domain;

namespace Guliver_Backend_Assignment.ApplicationCore;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Question, QuestionDto>().ReverseMap();
        CreateMap<Answer, AnswerDto>().ReverseMap();
    }
}