using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComplexObjectController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<ComplexObjectDto>> Get()
        {
            await Task.Delay(1000);

            return GetComplexObjectDtos();
        }

        [HttpGet("{id}")]
        public async Task<ComplexObjectDto> Get(int id)
        {
            await Task.Delay(1000);

            return GetComplexObjectDtos().FirstOrDefault(x => x.Id == id);
        }

        private IEnumerable<ComplexObjectDto> GetComplexObjectDtos()
        {
            return new ComplexObjectDto[]
            {
                new ComplexObjectDto
                {
                    Id = 1,
                    Name = "ComplexObject #1",
                    Groups = new List<ComplexObjectGroupDto>
                    {
                        new ComplexObjectGroupDto
                        {
                            Id = 1,
                            Name = "ComplexObject #1 Group #1",
                            Items = new List<ComplexObjectGroupItemDto>
                            {
                                new ComplexObjectGroupItemDto {Id = 11, Name = "ComplexObject #1 Group #1 Item 1"},
                                new ComplexObjectGroupItemDto {Id = 12, Name = "ComplexObject #1 Group #1 Item 2"},
                                new ComplexObjectGroupItemDto {Id = 13, Name = "ComplexObject #1 Group #1 Item 3"},
                            }
                        },
                        new ComplexObjectGroupDto
                        {
                            Id = 2,
                            Name = "ComplexObject #1 Group #2",
                            Items = new List<ComplexObjectGroupItemDto>
                            {
                                new ComplexObjectGroupItemDto {Id = 21, Name = "ComplexObject #1 Group #2 Item 1"},
                                new ComplexObjectGroupItemDto {Id = 22, Name = "ComplexObject #1 Group #2 Item 2"},
                                new ComplexObjectGroupItemDto {Id = 23, Name = "ComplexObject #1 Group #2 Item 3"},
                            }
                        }
                    }
                },
                new ComplexObjectDto
                {
                    Id = 2,
                    Name = "ComplexObject #2",
                    Groups = new List<ComplexObjectGroupDto>
                    {
                        new ComplexObjectGroupDto
                        {
                            Id = 1,
                            Name = "ComplexObject #2 Group #1",
                            Items = new List<ComplexObjectGroupItemDto>
                            {
                                new ComplexObjectGroupItemDto {Id = 11, Name = "ComplexObject #2 Group #1 Item 1"},
                                new ComplexObjectGroupItemDto {Id = 12, Name = "ComplexObject #2 Group #1 Item 2"},
                                new ComplexObjectGroupItemDto {Id = 13, Name = "ComplexObject #2 Group #1 Item 3"},
                            }
                        },
                        new ComplexObjectGroupDto
                        {
                            Id = 2,
                            Name = "ComplexObject #2 Group #2",
                            Items = new List<ComplexObjectGroupItemDto>
                            {
                                new ComplexObjectGroupItemDto {Id = 21, Name = "ComplexObject #2 Group #2 Item 1"},
                                new ComplexObjectGroupItemDto {Id = 22, Name = "ComplexObject #2 Group #2 Item 2"},
                                new ComplexObjectGroupItemDto {Id = 23, Name = "ComplexObject #2 Group #2 Item 3"},
                            }
                        }
                    }
                },
                new ComplexObjectDto
                {
                    Id = 3,
                    Name = "ComplexObject #3",
                    Groups = new List<ComplexObjectGroupDto>
                    {
                        new ComplexObjectGroupDto
                        {
                            Id = 1,
                            Name = "ComplexObject #3 Group #1",
                            Items = new List<ComplexObjectGroupItemDto>
                            {
                                new ComplexObjectGroupItemDto {Id = 11, Name = "ComplexObject #3 Group #1 Item 1"},
                                new ComplexObjectGroupItemDto {Id = 12, Name = "ComplexObject #3 Group #1 Item 2"},
                                new ComplexObjectGroupItemDto {Id = 13, Name = "ComplexObject #3 Group #1 Item 3"},
                            }
                        },
                        new ComplexObjectGroupDto
                        {
                            Id = 2,
                            Name = "ComplexObject #3 Group #2",
                            Items = new List<ComplexObjectGroupItemDto>
                            {
                                new ComplexObjectGroupItemDto {Id = 21, Name = "ComplexObject #3 Group #2 Item 1"},
                                new ComplexObjectGroupItemDto {Id = 22, Name = "ComplexObject #3 Group #2 Item 2"},
                                new ComplexObjectGroupItemDto {Id = 23, Name = "ComplexObject #3 Group #2 Item 3"},
                            }
                        }
                    }
                }
            };
        }
    }
}
