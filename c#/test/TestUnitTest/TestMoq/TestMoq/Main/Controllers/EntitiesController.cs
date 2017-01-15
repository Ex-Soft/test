using System;
using System.Linq;
using System.Collections.Generic;
using Main.DomainModel.Abstract;
using Main.DomainModel.Entities;

namespace Main.Controllers
{
	public class EntitiesController
	{
		private readonly IEntitiesRepository _entitiesRepository;

        public int PageSize=2;

        public EntitiesController(IEntitiesRepository entitiesRepository)
        {
            _entitiesRepository = entitiesRepository;
        }

        public EntitiesViewResult List(int page)
        {
			var numEntities = _entitiesRepository.Entities.Count();

	        return new EntitiesViewResult
	        {
		        TotalPages = (int) Math.Ceiling((double) numEntities/PageSize),
		        CurrentPage = page,
		        Entities = _entitiesRepository.Entities
			        .Skip((page - 1)*PageSize)
			        .Take(PageSize)
			        .ToList()
	        };
        }
	}

	public class EntitiesViewResult
	{
		public int TotalPages { get; set; }
		public int CurrentPage { get; set; }
		public IEnumerable<Entity> Entities { get; set; } 
	}
}
