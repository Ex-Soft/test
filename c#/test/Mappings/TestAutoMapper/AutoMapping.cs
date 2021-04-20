using AutoMapper;

namespace TestAutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            _ = CreateMap<Class1Src, Class1Dest>();

            _ = CreateMap<Class2Src, Class1Dest>()
                .ForMember(dest => dest.PDateTime, opt => opt.MapFrom(src => Utils.FromUnixEpochSeconds(src.PDateTime)));

            _ = CreateMap<Class1Src, Class3Dest>()
                .ForMember(dest => dest.PI, opt => opt.MapFrom(src => src.PInt))
                .ForMember(dest => dest.PS, opt => opt.MapFrom(src => src.PString))
                .ForMember(dest => dest.PDT, opt => opt.MapFrom(src => src.PDateTime));

            _ = CreateMap<Class2Src, Class3Dest>()
                .ForMember(dest => dest.PI, opt => opt.MapFrom(src => src.PInt))
                .ForMember(dest => dest.PS, opt => opt.MapFrom(src => src.PString))
                .ForMember(dest => dest.PDT, opt => opt.MapFrom(src => Utils.FromUnixEpochSeconds(src.PDateTime)));
        }
    }
}
