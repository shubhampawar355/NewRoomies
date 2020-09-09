using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roomies.Models.Repository
{
	public interface IAddressRepository
	{
		Address CreateAddress(Address address);
		Address ReadAddress(int addId);
		Address UpdateAddress(Address address);
		Address DeleteAddress(Address address);

	}
}
