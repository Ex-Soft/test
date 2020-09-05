using AutoMapper;
using WebApi.Models;

namespace WebApi.Mapping
{
    public class Class2Profile : Profile
    {
        public Class2Profile()
        {
            _ = CreateMap<Class2Request, Class2Dto>();
            _ = CreateMap<Class2Dto, Class2Response>();
        }
    }
}
