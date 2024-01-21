using AutoMapper;
using Employee.Common.Models;

namespace Employee.API.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Entities.Employee, EmployeeDto>()
                            .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                            .ReverseMap();
        }
    }
}
