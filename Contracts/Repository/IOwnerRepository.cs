using System;
using System.Collections.Generic;
using Entities.ExtendedModels;
using Entities.Models;

namespace Contracts.Repository
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        IEnumerable<Owner> GetAllOwners();

        Owner GetOwnerById(Guid ownerId);

        OwnerExtended GetOwnerWithDetails(Guid ownerId);

        void CreateOwner(Owner newOwner);

        void UpdateOwner(Owner dbOwner, Owner owner);
    }
}