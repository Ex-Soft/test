using AutoMapper;
using WebApi.Models;

namespace WebApi.Mapping
{
    public class Class1Profile : Profile
    {
        public Class1Profile()
        {
            _ = CreateMap<Class1Request, Class1Dto>();
            _ = CreateMap<Class1Dto, Class1Response>();
        }
    }
}
