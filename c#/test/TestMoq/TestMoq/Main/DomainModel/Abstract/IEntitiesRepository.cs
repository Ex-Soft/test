using System.Linq;
using Main.DomainModel.Entities;

namespace Main.DomainModel.Abstract
{
	public interface IEntitiesRepository
	{
		IQueryable<Entity> Entities { get; }
	}
}
