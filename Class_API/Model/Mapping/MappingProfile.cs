using AutoMapper;
using Class_API.Model.Contracts;
using Class_API.Model.Entity;

namespace Class_API.Model.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            
            //Section
            CreateMap<Section, SectionDTO>();
            CreateMap<CreateSection, Section>();
            CreateMap<UpdateSection,Section>();
            CreateMap<DeleteSection, Section>();

            //Student
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.MiddleName} {src.LastName}"));
            CreateMap<CreateStudent, Student>();
            CreateMap<UpdateStudent, Student>();
            CreateMap<DeleteSection, Student>();


        }
    }
}
