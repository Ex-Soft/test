using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<TodoDto>> Get()
        {
            await Task.Delay(1000);

            return GetTodoDtos();
        }

        [HttpGet("{id}")]
        public async Task<TodoDto> Get(int id)
        {
            await Task.Delay(1000);

            return GetTodoDtos().FirstOrDefault(x => x.Id == id);
        }

        private IEnumerable<TodoDto> GetTodoDtos()
        {
            return new TodoDto[]
            {
                new TodoDto
                {
                    Id = 1,
                    Name = "Todo #1",
                    Groups = new List<TodoGroupDto>
                    {
                        new TodoGroupDto
                        {
                            Id = 1,
                            Name = "Todo #1 Group #1",
                            Items = new List<TodoGroupItemDto>
                            {
                                new TodoGroupItemDto {Id = 11, Name = "Todo #1 Group #1 Item 1"},
                                new TodoGroupItemDto {Id = 12, Name = "Todo #1 Group #1 Item 2"},
                                new TodoGroupItemDto {Id = 13, Name = "Todo #1 Group #1 Item 3"},
                            }
                        },
                        new TodoGroupDto
                        {
                            Id = 2,
                            Name = "Todo #1 Group #2",
                            Items = new List<TodoGroupItemDto>
                            {
                                new TodoGroupItemDto {Id = 21, Name = "Todo #1 Group #2 Item 1"},
                                new TodoGroupItemDto {Id = 22, Name = "Todo #1 Group #2 Item 2"},
                                new TodoGroupItemDto {Id = 23, Name = "Todo #1 Group #2 Item 3"},
                            }
                        }
                    }
                },
                new TodoDto
                {
                    Id = 3,
                    Name = "Todo #2",
                    Groups = new List<TodoGroupDto>
                    {
                        new TodoGroupDto
                        {
                            Id = 1,
                            Name = "Todo #2 Group #1",
                            Items = new List<TodoGroupItemDto>
                            {
                                new TodoGroupItemDto {Id = 11, Name = "Todo #2 Group #1 Item 1"},
                                new TodoGroupItemDto {Id = 12, Name = "Todo #2 Group #1 Item 2"},
                                new TodoGroupItemDto {Id = 13, Name = "Todo #2 Group #1 Item 3"},
                            }
                        },
                        new TodoGroupDto
                        {
                            Id = 2,
                            Name = "Todo #2 Group #2",
                            Items = new List<TodoGroupItemDto>
                            {
                                new TodoGroupItemDto {Id = 21, Name = "Todo #2 Group #2 Item 1"},
                                new TodoGroupItemDto {Id = 22, Name = "Todo #2 Group #2 Item 2"},
                                new TodoGroupItemDto {Id = 23, Name = "Todo #2 Group #2 Item 3"},
                            }
                        }
                    }
                },
                new TodoDto
                {
                    Id = 5,
                    Name = "Todo #3",
                    Groups = new List<TodoGroupDto>
                    {
                        new TodoGroupDto
                        {
                            Id = 1,
                            Name = "Todo #3 Group #1",
                            Items = new List<TodoGroupItemDto>
                            {
                                new TodoGroupItemDto {Id = 11, Name = "Todo #3 Group #1 Item 1"},
                                new TodoGroupItemDto {Id = 12, Name = "Todo #3 Group #1 Item 2"},
                                new TodoGroupItemDto {Id = 13, Name = "Todo #3 Group #1 Item 3"},
                            }
                        },
                        new TodoGroupDto
                        {
                            Id = 2,
                            Name = "Todo #3 Group #2",
                            Items = new List<TodoGroupItemDto>
                            {
                                new TodoGroupItemDto {Id = 21, Name = "Todo #3 Group #2 Item 1"},
                                new TodoGroupItemDto {Id = 22, Name = "Todo #3 Group #2 Item 2"},
                                new TodoGroupItemDto {Id = 23, Name = "Todo #3 Group #2 Item 3"},
                            }
                        }
                    }
                }
            };
        }
    }
}
