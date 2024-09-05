using AutoMapper;
using LoanApp_API.Models;
using LoanApp_API.Models.DTOs;

namespace LoanApp_API.Mappings
{
    public class LoanAppProfile : Profile
    {
        public LoanAppProfile()
        {
            CreateMap<LoanApp, LoanAppDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            CreateMap<CreateLoanAppDto, LoanApp>();
            CreateMap<Document, DocumentDto>();
        }
    }
}
