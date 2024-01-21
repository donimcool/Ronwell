using AutoMapper;

namespace Employee.API.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Entities.Employee, Models.EmployeeDto>()
                            .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                            .ReverseMap();
        }
    }
}
