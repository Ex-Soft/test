using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonProject.Mappers
{
    public interface IMapper
    {
        object Map(object source, Type sourceType, Type destinationType);
    }
}
