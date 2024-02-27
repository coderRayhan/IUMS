using AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories;
using AspNetCoreHero.Boilerplate.Domain.Entities.Catalog;
using IUMS.Domain.Entities.Academic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IUMS.Application.Interfaces.Repositories.Academic
{
	public interface ISessionRepository
	{
		IQueryable<Session> Sessions { get; }

		Task<List<Session>> GetListAsync();

		Task<Session> GetByIdAsync(int SessionId);

		Task<int> InsertAsync(Session Session);

		Task UpdateAsync(Session Session);

		Task DeleteAsync(Session Session);
	}
}
