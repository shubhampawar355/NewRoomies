using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roomies.Models.Repository
{

	public interface IFilterRepository
	{
		Filter CreateFilter(Filter Filter);
		Filter ReadFilter(int addId);
		Filter UpdateFilter(Filter Filter);
		Filter DeleteFilter(Filter Filter);

	}
}
