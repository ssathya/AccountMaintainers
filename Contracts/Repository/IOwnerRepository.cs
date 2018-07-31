using System.Collections.Generic;
using Entities.Models;

namespace Contracts.Repository
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        IEnumerable<Owner> GetAllOwners();
    }
}