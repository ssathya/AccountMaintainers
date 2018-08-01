using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Repository;
using Entities;
using Entities.ExtendedModels;
using Entities.Models;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return FindAll()
                .OrderBy(o => o.Name);
        }

        public Owner GetOwnerById(Guid ownerId)
        {
            return Find(o => o.Id.Equals(ownerId));
        }

        public OwnerExtended GetOwnerWithDetails(Guid ownerId)
        {
            return new OwnerExtended(GetOwnerById(ownerId))
            {
                Accounts = RepositoryContext.Accounts
                    .Where(a => a.OwnerId == ownerId)
            };
        }
    }
}